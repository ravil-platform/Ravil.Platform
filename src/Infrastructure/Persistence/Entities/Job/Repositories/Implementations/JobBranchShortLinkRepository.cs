namespace Persistence.Entities.Job.Repositories;

public class JobBranchShortLinkRepository : Repository<JobBranchShortLink>, IJobBranchShortLinkRepository
{
    internal JobBranchShortLinkRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}