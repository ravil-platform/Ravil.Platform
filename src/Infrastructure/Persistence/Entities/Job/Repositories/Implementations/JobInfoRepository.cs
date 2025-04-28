namespace Persistence.Entities.Job.Repositories.Implementations;

public class JobInfoRepository : Repository<JobInfo>, IJobInfoRepository
{
    protected ApplicationDbContext ApplicationDbContext { get; }
    internal JobInfoRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }
}