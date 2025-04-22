namespace Application.Features.User.Queries.CheckIsJobBookMarked;

public class CheckIsJobBookMarkedQueryHandler : IRequestHandler<CheckIsJobBookMarkedQuery, UserJobBookMarkViewModel>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }
    protected UserManager<ApplicationUser> UserManager { get; }

    public CheckIsJobBookMarkedQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
        UserManager = userManager;
    }

    public async Task<Result<UserJobBookMarkViewModel>> Handle(CheckIsJobBookMarkedQuery request, CancellationToken cancellationToken)
    {
        #region ( Check Is Job BookMarked )

        var jobBranch = await UnitOfWork.JobBranchRepository.TableNoTracking.Include(a => a.JobUserBookMarks)
            .SingleOrDefaultAsync(b => b.Id == request.JobBranchId, cancellationToken: cancellationToken);
        
        if (jobBranch is null or { JobUserBookMarks: null })
        {
            var result = new UserJobBookMarkViewModel();
            result.BookCount = 0;
            result.IsBooked = false;

            return result;
        }
        if (jobBranch is { JobUserBookMarks: null })
        {
            var result = new UserJobBookMarkViewModel();
            result.BookCount = 0;
            result.IsBooked = false;

            return result;
        }

        var userJobBookMark = jobBranch.JobUserBookMarks!.FirstOrDefault(a => a.UserId.Equals(request.UserId));
        
        if (userJobBookMark is not null)
        {
            var result = Mapper.Map<UserJobBookMarkViewModel>(userJobBookMark);
            result.BookCount = jobBranch.JobUserBookMarks?.Count ?? 0;
            result.IsBooked = true;

            return result;
        }
        else
        {
            var result = new UserJobBookMarkViewModel();
            result.BookCount = 0;
            result.IsBooked = false;

            return result;
        }

        #endregion
    }
}