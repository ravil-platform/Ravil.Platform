using Persistence.Entities.Job.Repositories.Interfaces;

namespace Persistence.Entities.Job.Repositories.Implementations;

public class JobTimeWorkRepository : Repository<JobTimeWork>, IJobTimeWorkRepository
{
    internal JobTimeWorkRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}