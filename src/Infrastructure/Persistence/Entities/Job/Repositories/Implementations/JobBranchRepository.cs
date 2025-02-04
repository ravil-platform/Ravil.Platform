namespace Persistence.Entities.Job.Repositories.Implementations;

public class JobBranchRepository : Repository<JobBranch>, IJobBranchRepository
{
    protected ApplicationDbContext ApplicationDbContext { get; }
    internal JobBranchRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }

    public async Task<IQueryable<JobBranch>> GetJobRelatedJobBranches(int categoryId, int cityId, int take)
    {
        var jobIds = await ApplicationDbContext.JobCategory.AsNoTracking()
            .Where(a => a.CategoryId.Equals(categoryId))
            .Select(a => a.JobId).Distinct().ToListAsync();

        var relatedCities = await ApplicationDbContext.JobBranchRelatedJobs.AsNoTracking()
            .Where(j => j.CurrentCityId == cityId)
            .OrderBy(j => j.Sort)
            .ToListAsync();
       
        var jobBranch = ApplicationDbContext.JobBranch.AsQueryable()
            .Where(a => a.IsDeleted != null && !a.IsDeleted.Value)
            .Where(a => a.Job.Status == JobBranchStatus.Accepted);

        if (relatedCities.Any())
        {
            foreach (var relatedCity in relatedCities)
            {
                var jobBranchQueryable = ApplicationDbContext.Address.Include(c => c.JobBranch)
                    .Where(a => a.CityId == relatedCity.DisplayedCityId).Select(a => a.JobBranch);

                jobBranch = jobBranchQueryable.Where(j => jobIds.Contains(j.JobId)).Take(take);

                //jobBranch = jobBranch
                //    .Include(s => s.Job)
                //    .Include(s => s.Address)
                //    .ThenInclude(s => s.Location)
                //    .Include(s => s.JobBranchGalleries)
                //    .Where(j => j.Address.CityId == relatedCity.DisplayedCityId && jobIds.Contains(j.JobId)).Take(take);
            }
        }

        return jobBranch;
    }

    public async Task<List<JobBranch>> GetJobBranchesByCategoryId(int categoryId, int take = 10)
    {
        var jobs = await ApplicationDbContext.JobCategory.AsNoTracking()
            .Include(a => a.Job)
            .Where(j => j.CategoryId == categoryId)
            .Select(a => a.Job)
            .ToListAsync();

        var jobBranches = await ApplicationDbContext.JobBranch.AsNoTracking()
            .Include(a => a.Job).Include(a => a.JobBranchGalleries)
            .Include(a => a.Address).ThenInclude(a => a.Location)
            .Where(a => jobs.Select(aa => aa.Id).Contains(a.JobId))
            .Where(a => a.IsDeleted != null && !a.IsDeleted.Value)
            .Where(a => a.Job.Status == JobBranchStatus.Accepted)
            .Take(take).ToListAsync();

        return jobBranches;
    }
    
    public async Task<List<JobBranch>> GetRelatedJobBranches(int jobId, int take = 10)
    {
        var jobCategory = await ApplicationDbContext.JobCategory.AsNoTracking().Where(j => j.JobId == jobId).FirstOrDefaultAsync();

        var jobsId = await ApplicationDbContext.JobCategory.AsNoTracking()
            .Include(a => a.Job)
            .Where(j => !j.JobId.Equals(jobId))
            .Where(j => j.CategoryId == jobCategory!.CategoryId)
            .Select(a => a.JobId)
            .ToListAsync();

        var jobBranches = await ApplicationDbContext.JobBranch.AsNoTracking()
            .Include(a => a.Job).Include(a => a.JobBranchGalleries)
            .Include(a => a.Job.JobCategories).ThenInclude(a => a.Category)
            .Include(a => a.Address).ThenInclude(a => a.Location)
            .Where(a => a.IsDeleted != null && !a.IsDeleted.Value)
            .Where(a => a.Job.Status == JobBranchStatus.Accepted)
            .Where(a => jobsId.Contains(a.JobId))
            .Take(take).ToListAsync();

        return jobBranches;
    }
}