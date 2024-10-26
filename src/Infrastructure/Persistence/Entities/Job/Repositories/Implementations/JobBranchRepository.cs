using Persistence.Entities.Job.Repositories.Interfaces;

namespace Persistence.Entities.Job.Repositories.Implementations;

public class JobBranchRepository : Repository<JobBranch>, IJobBranchRepository
{
    internal JobBranchRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}