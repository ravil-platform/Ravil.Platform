using System.Collections;
using AngleSharp.Common;
using Domain.Entities.Subscription;
using Resources.Messages;
using ViewModels.QueriesResponseViewModel.Subscription;

namespace Application.Features.Job.Commands.SetAdsClickSetting;

public class SetAdsClickSettingCommandHandler(
    IMapper mapper,
    IUnitOfWork unitOfWork,
    UserManager<ApplicationUser> userManager,
    IHttpContextAccessor httpContextAccessor,
    Logging.Base.ILogger<SetAdsClickSettingCommandHandler> logger)
    : IRequestHandler<SetAdsClickSettingCommand, ClickAdsSettingViewModel>
{
    #region ( Properties )

    protected IMapper Mapper { get; } = mapper;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected UserManager<ApplicationUser> UserManager { get; } = userManager;
    protected IHttpContextAccessor HttpContextAccessor { get; } = httpContextAccessor;
    protected HttpContext? HttpContext { get; } = httpContextAccessor.HttpContext;
    protected Logging.Base.ILogger<SetAdsClickSettingCommandHandler> Logger { get; } = logger;

    #endregion

    public async Task<Result<ClickAdsSettingViewModel>> Handle(SetAdsClickSettingCommand request, CancellationToken cancellationToken)
    {
        #region ( Set Ads Click Setting Command )

        #region ( Validations )

        if (HttpContextAccessor.HttpContext?.User.Identity is null or { IsAuthenticated: false })
        {
            return Result.Fail(Validations.BadRequestException);
        }

        var businessOwnerId = UserManager.GetUserId(HttpContext!.User);
        var businessOwner = await UnitOfWork.ApplicationUserRepository.TableNoTracking
            .SingleOrDefaultAsync(a => a.Id.Equals(businessOwnerId), cancellationToken: cancellationToken);

        if (businessOwner is null)
            return Result.Fail(Validations.BadRequestException);

        #endregion

        try
        {
            var clickAdsSettings = await UnitOfWork.ClickAdsSettingRepository.Table
                .Where(a => a.UserId == request.UserId)
                .SingleOrDefaultAsync(cancellationToken: cancellationToken) ?? new ClickAdsSetting
            {
                Id = 1,
                Status = true,
                AdDisplayRange = 0,
                MaxCostPerClick = 0,
            };

            var updateClickAdsSettings = Mapper.Map(request, clickAdsSettings);

            await UnitOfWork.ClickAdsSettingRepository.UpdateAsync(updateClickAdsSettings);
            await UnitOfWork.SaveAsync();
            
            var clickAdsSettingViewModel = Mapper.Map<ClickAdsSettingViewModel>(updateClickAdsSettings);
            return clickAdsSettingViewModel;
        }
        catch (Exception e)
        {
            Logger.LogError(exception: e, e.InnerException?.Message ?? e.Message, new Hashtable(request.ToDictionary()));
            throw;
        }

        #endregion
    }
}