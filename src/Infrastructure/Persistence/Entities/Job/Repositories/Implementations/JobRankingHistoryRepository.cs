namespace Persistence.Entities.Job.Repositories.Implementations;

public class JobRankingHistoryRepository : Repository<JobRankingHistory>, IJobRankingHistoryRepository
{
    protected ApplicationDbContext ApplicationDbContext { get; }
    internal JobRankingHistoryRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }
}