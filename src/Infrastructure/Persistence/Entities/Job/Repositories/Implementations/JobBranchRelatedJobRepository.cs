namespace Persistence.Entities.Job.Repositories.Implementations;

public class JobBranchRelatedJobRepository : Repository<JobBranchRelatedJob>, IJobBranchRelatedJobRepository
{
    internal JobBranchRelatedJobRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}