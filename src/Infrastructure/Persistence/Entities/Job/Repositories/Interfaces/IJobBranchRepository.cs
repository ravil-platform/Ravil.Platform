namespace Persistence.Entities.Job.Repositories.Interfaces;

public interface IJobBranchRepository : IRepository<JobBranch>
{
    Task<IQueryable<JobBranch>> GetJobRelatedJobBranches(int categoryId, int cityId, int take);
    Task<List<JobBranch>> GetJobBranchesByCategoryId(int categoryId, int take = 10);
    Task<List<JobBranch>> GetRelatedJobBranches(int jobId, int take = 10);
}