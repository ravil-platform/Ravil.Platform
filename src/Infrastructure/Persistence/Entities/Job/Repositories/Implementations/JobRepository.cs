namespace Persistence.Entities.Job.Repositories.Implementations;

public class JobRepository : Repository<Domain.Entities.Job.Job>, IJobRepository
{
    protected ApplicationDbContext ApplicationDbContext { get; }
    internal JobRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }

    public async Task<List<Domain.Entities.Job.Job>> GetNewestJobs(int take = 10)
    {
        var result = await ApplicationDbContext.Job.AsNoTracking().Where(j => !(bool)j.IsDeleted).OrderByDescending(j => j.CreateDate).Take(take).ToListAsync();

        return result;
    }

    public async Task<List<Domain.Entities.Job.Job>> GetBestJobs(int take = 10)
    {
        var result = await ApplicationDbContext.Job.AsNoTracking().Where(j => !(bool)j.IsDeleted).OrderByDescending(j => j.ViewCountTotal).Take(take).ToListAsync();

        return result;
    }

    public async Task<List<Domain.Entities.Job.Job>> GetRelatedJobs(int jobId, int take = 10)
    {
        var jobCategory = await ApplicationDbContext.JobCategory.AsNoTracking().Where(j => j.JobId == jobId).FirstOrDefaultAsync();

        var jobs = await ApplicationDbContext.JobCategory.AsNoTracking()
            .Include(a => a.Job)
            .Where(j => !j.JobId.Equals(jobId))
            .Where(j => j.CategoryId == jobCategory.CategoryId)
            .Select(a => a.Job)
            .ToListAsync();

        return jobs;
    }

    public async Task<List<Domain.Entities.Job.Job>> GetJobsByCategoryId(int categoryId, int take = 10)
    {
        var jobs = await ApplicationDbContext.JobCategory.AsNoTracking()
            .Include(a => a.Job)
            .Where(j => j.CategoryId == categoryId)
            .Select(a => a.Job)
            .ToListAsync();

        return jobs;
    }
}