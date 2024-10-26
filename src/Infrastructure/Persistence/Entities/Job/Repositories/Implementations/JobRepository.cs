using Persistence.Entities.Job.Repositories.Interfaces;

namespace Persistence.Entities.Job.Repositories.Implementations;

public class JobRepository : Repository<Domain.Entities.Job.Job>, IJobRepository
{
    internal JobRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}