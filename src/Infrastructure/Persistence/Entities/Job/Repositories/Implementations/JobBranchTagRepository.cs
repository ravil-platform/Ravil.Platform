namespace Persistence.Entities.Job.Repositories;

public class JobBranchTagRepository : Repository<JobBranchTag>, IJobBranchTagRepository
{
    internal JobBranchTagRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}