using System.Collections;
using AngleSharp.Common;
using Resources.Messages;

namespace Application.Features.Job.Commands.RemoveJobBranchGalleries;

public class RemoveJobBranchGalleriesCommandHandler(
    IMapper mapper,
    IUnitOfWork unitOfWork,
    IFtpService ftpService,
    UserManager<ApplicationUser> userManager,
    IHttpContextAccessor httpContextAccessor,
    Logging.Base.ILogger<RemoveJobBranchGalleriesCommandHandler> logger)
    : IRequestHandler<RemoveJobBranchGalleriesCommand>
{
    #region ( Properties )

    protected IMapper Mapper { get; } = mapper;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected IFtpService FtpService { get; } = ftpService;
    protected UserManager<ApplicationUser> UserManager { get; } = userManager;
    protected IHttpContextAccessor HttpContextAccessor { get; } = httpContextAccessor;
    protected HttpContext? HttpContext { get; } = httpContextAccessor.HttpContext;
    protected Logging.Base.ILogger<RemoveJobBranchGalleriesCommandHandler> Logger { get; } = logger;

    #endregion

    public async Task<Result> Handle(RemoveJobBranchGalleriesCommand request, CancellationToken cancellationToken)
    {
        #region ( Remove JobBranch Galleries Command )

        #region ( Validations )

        if (HttpContextAccessor.HttpContext?.User.Identity is null or { IsAuthenticated: false })
        {
            return Result.Fail(Validations.BadRequestException);
        }

        #endregion

        try
        {
            await UnitOfWork.BeginTransactionAsync(cancellationToken: cancellationToken);

            var currentJobBranchGallery = await UnitOfWork.JobBranchGalleryRepository.Table
                .Where(a => a.Id == request.GalleryImageId && a.JobBranchId == request.JobBranchId)
                .SingleOrDefaultAsync(cancellationToken: cancellationToken);

            if (currentJobBranchGallery is null)
                return Result.Fail(Validations.BadRequestException);

            if (!string.IsNullOrWhiteSpace(currentJobBranchGallery.ImageName))
            {
                var deleteFileResponse = await FtpService.DeleteFileToFtpServer(Paths.JobBranchGallery + request.JobBranchId, currentJobBranchGallery.ImageName);
                if (!deleteFileResponse)
                { 
                    await UnitOfWork.RollbackTransactionAsync(cancellationToken: cancellationToken);
                    return Result.Fail(Validations.BadRequestException);
                }

                await UnitOfWork.JobBranchGalleryRepository.DeleteAsync(currentJobBranchGallery);
                await UnitOfWork.SaveAsync();

                await UnitOfWork.CommitTransactionAsync(cancellationToken: cancellationToken);

                return Result.Ok();
            }
        }
        catch (Exception e)
        {
            Logger.LogError(exception: e, e.InnerException?.Message ?? e.Message, new Hashtable(request.ToDictionary()));
            await UnitOfWork.RollbackTransactionAsync(cancellationToken: cancellationToken);
            throw;
        }

        return Result.Fail(Validations.BadRequestException);

        #endregion
    }
}