using Persistence.Entities.Job.Repositories.Interfaces;

namespace Persistence.Entities.Job.Repositories.Implementations;

public class JobBranchTagRepository : Repository<JobBranchTag>, IJobBranchTagRepository
{
    internal JobBranchTagRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}