namespace Persistence.Entities.Job.Repositories.Implementations;

public class JobBranchTagRepository : Repository<JobBranchTag>, IJobBranchTagRepository
{
    internal JobBranchTagRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}