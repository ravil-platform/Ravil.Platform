namespace Persistence.Entities.Job.Repositories.Implementations;

public class JobBranchAdsRepository : Repository<JobBranchAds>, IJobBranchAdsRepository
{
    protected ApplicationDbContext ApplicationDbContext { get; }
    internal JobBranchAdsRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }

    public async Task<List<JobBranch>> GetAllJobAds()
    {
        var jobBranchIds = await ApplicationDbContext.JobBranchAds.Select(j => j.JobBranchId).ToListAsync();

        var data = new List<JobBranch>();

        foreach (var jobBranchId in jobBranchIds)
        {
            var jobBranch = await ApplicationDbContext.JobBranch.Where(j => j.Id == jobBranchId).SingleOrDefaultAsync();

            if (jobBranch != null)
            {
                data.Add(jobBranch);
            }
        }

        return data;
    }
}