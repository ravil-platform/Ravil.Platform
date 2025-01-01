namespace Persistence.Entities.Job.Repositories.Interfaces;

public interface IJobBranchRepository : IRepository<JobBranch>
{
    Task<IQueryable<JobBranch>> GetJobRelatedJobBranches(int categoryId, int cityId, int take);
}