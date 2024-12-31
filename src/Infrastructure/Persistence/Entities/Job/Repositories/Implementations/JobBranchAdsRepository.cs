namespace Persistence.Entities.Job.Repositories.Implementations;

public class JobBranchAdsRepository : Repository<JobBranchAds>, IJobBranchAdsRepository
{
    internal JobBranchAdsRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}