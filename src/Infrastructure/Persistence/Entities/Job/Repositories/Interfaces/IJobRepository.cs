using ViewModels.AdminPanel.Filter;

namespace Persistence.Entities.Job.Repositories.Interfaces;

public interface IJobRepository : IRepository<Domain.Entities.Job.Job>
{
    Task<List<Domain.Entities.Job.Job>> GetNewestJobs(int take = 10);
    Task<List<Domain.Entities.Job.Job>> GetBestJobs(int take = 10);
    Task<List<Domain.Entities.Job.Job>> GetRelatedJobs(int jobId, int take = 10);
    Task<List<Domain.Entities.Job.Job>> GetJobsByCategoryId(int categoryId, int take = 10);

    Task<List<Domain.Entities.Job.Job>> SearchJob(string? title = null, string? city = null);

    Task<bool> JobRouteExist(string route);
    Task<bool> JobBranchRouteExist(string route);
    Task SetIsDelete(int jobId, bool delete);

    JobFilterViewModel GetByAdminFilter(JobFilterViewModel filter);
}