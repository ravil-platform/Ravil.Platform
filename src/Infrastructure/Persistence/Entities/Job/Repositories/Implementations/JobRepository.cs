namespace Persistence.Entities.Job.Repositories;

public class JobRepository : Repository<Domain.Entities.Job.Job>, IJobRepository
{
    internal JobRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}