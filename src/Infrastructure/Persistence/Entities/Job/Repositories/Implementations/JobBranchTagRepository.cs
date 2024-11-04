namespace Persistence.Entities.Job.Repositories.Implementations;

public class JobBranchTagRepository : Repository<JobBranchTag>, IJobBranchTagRepository
{
    protected ApplicationDbContext ApplicationDbContext { get; }

    internal JobBranchTagRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }

}