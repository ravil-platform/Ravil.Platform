using Persistence.Entities.Job.Repositories.Interfaces;

namespace Persistence.Entities.Job.Repositories.Implementations;

public class JobServiceRepository : Repository<JobService>, IJobServiceRepository
{
    internal JobServiceRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}