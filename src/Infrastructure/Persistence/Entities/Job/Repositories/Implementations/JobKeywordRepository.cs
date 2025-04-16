namespace Persistence.Entities.Job.Repositories.Implementations;

public class JobKeywordRepository : Repository<JobKeyword>, IJobKeywordRepository
{
    protected ApplicationDbContext ApplicationDbContext { get; }
    internal JobKeywordRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }
}