namespace Persistence.Entities.Job.Repositories.Implementations;

public class JobBranchShortLinkRepository : Repository<JobBranchShortLink>, IJobBranchShortLinkRepository
{
    internal JobBranchShortLinkRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}