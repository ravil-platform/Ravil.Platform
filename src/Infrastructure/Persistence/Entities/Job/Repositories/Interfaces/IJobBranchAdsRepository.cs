namespace Persistence.Entities.Job.Repositories.Interfaces;

public interface IJobBranchAdsRepository : IRepository<JobBranchAds>
{
    Task<List<JobBranch>> GetAllJobAds();
}