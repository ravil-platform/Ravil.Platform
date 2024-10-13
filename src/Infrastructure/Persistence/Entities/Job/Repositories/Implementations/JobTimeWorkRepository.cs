namespace Persistence.Entities.Job.Repositories;

public class JobTimeWorkRepository : Repository<JobTimeWork>, IJobTimeWorkRepository
{
    internal JobTimeWorkRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}