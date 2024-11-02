namespace Persistence.Entities.Job.Repositories.Implementations;

public class JobTagRepository : Repository<JobTag>, IJobTagRepository
{
    internal JobTagRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}