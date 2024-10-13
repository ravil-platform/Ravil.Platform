namespace Persistence.Entities.Job.Repositories;

public class JobBranchAttrRepository : Repository<JobBranchAttr>, IJobBranchAttrRepository
{
    internal JobBranchAttrRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}