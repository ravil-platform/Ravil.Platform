namespace Persistence.Entities.Job.Repositories.Interfaces;

public interface IJobRepository : IRepository<Domain.Entities.Job.Job>
{
    Task<List<Domain.Entities.Job.Job>> GetNewestJobs(int take = 10);
    Task<List<Domain.Entities.Job.Job>> GetBestJobs(int take = 10);
    Task<List<Domain.Entities.Job.Job>> GetRelatedJobs(int jobId, int take = 10);
    Task<List<Domain.Entities.Job.Job>> GetJobsByCategoryId(int categoryId, int take = 10);
}