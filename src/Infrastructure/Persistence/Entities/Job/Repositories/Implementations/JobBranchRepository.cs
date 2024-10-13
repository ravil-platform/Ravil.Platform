namespace Persistence.Entities.Job.Repositories;

public class JobBranchRepository : Repository<JobBranch>, IJobBranchRepository
{
    internal JobBranchRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}