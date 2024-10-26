using Persistence.Entities.Job.Repositories.Interfaces;

namespace Persistence.Entities.Job.Repositories.Implementations;

public class JobBranchAttrRepository : Repository<JobBranchAttr>, IJobBranchAttrRepository
{
    internal JobBranchAttrRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}