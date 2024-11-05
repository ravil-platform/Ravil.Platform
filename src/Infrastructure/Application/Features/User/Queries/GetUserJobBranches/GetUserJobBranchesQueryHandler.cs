namespace Application.Features.User.Queries.GetUserJobBranches;

public class GetUserJobBranchesQueryHandler : IRequestHandler<GetUserJobBranchesQuery, List<UserJobBranchesViewModel>>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }
    public GetUserJobBranchesQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<List<UserJobBranchesViewModel>>> Handle(GetUserJobBranchesQuery request, CancellationToken cancellationToken)
    {
        var userJobBranches = await UnitOfWork.JobBranchRepository.TableNoTracking
            .Where(j => j.UserId == request.UserId)
            .Include(j => j.Job)
            .ThenInclude(j => j.JobCategories)
            .ThenInclude(j => j.Category)
            .Include(j => j.JobUserBookMarks)
            .Select(jobBranch => new UserJobBranchesViewModel()
            {
                Id = jobBranch.Id,
                Title = jobBranch.Title,
                CommentCount = jobBranch.Comments.Count,
                BookMarkCount = jobBranch.JobUserBookMarks.Count(j => j.UserBookMarkType == UserBookMarkType.JobBranch),
                Route = jobBranch.Route,
                Categories = Mapper.Map<List<CategoryViewModel>>(jobBranch.Job.JobCategories.Select(j => j.Category).ToList()),
                PictureName = jobBranch.SmallPicture,
                ViewCount = jobBranch.ViewCount,
            })
            .ToListAsync(cancellationToken);

        return userJobBranches;
    }
}