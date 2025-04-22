using AutoMapper.QueryableExtensions;

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
            .Include(j => j.Comments)
            .Include(j => j.JobUserBookMarks)
            .Where(a => a.Job.Status == JobBranchStatus.Accepted)
            .ProjectTo<UserJobBranchesViewModel>(Mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return userJobBranches;
    }
}