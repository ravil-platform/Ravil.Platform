namespace Persistence.Entities.Job.Repositories.Implementations;

public class JobRankingRepository : Repository<JobRanking>, IJobRankingRepository
{
    protected ApplicationDbContext ApplicationDbContext { get; }
    internal JobRankingRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }
}