using AutoMapper.QueryableExtensions;

namespace Application.Features.User.Queries.GetUserJobBranches;

public class GetUserJobBranchesQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    : IRequestHandler<GetUserJobBranchesQuery, List<UserJobBranchesViewModel>>
{
    #region ( Dependencies )

    protected IMapper Mapper { get; } = mapper;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;

    #endregion

    public async Task<Result<List<UserJobBranchesViewModel>>> Handle(GetUserJobBranchesQuery request, CancellationToken cancellationToken)
    {
        #region ( Get User JobBranches Query)

        var userJobBranches = await UnitOfWork.JobBranchRepository.TableNoTracking
            .Where(j => j.UserId == request.UserId)
            .Include(j => j.Job)
            .ThenInclude(j => j.JobCategories)
            .ThenInclude(j => j.Category)
            .Include(j => j.Comments)
            .Include(j => j.JobUserBookMarks)
            .ProjectTo<UserJobBranchesViewModel>(Mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken: cancellationToken);

        return userJobBranches;

        #endregion
    }
}