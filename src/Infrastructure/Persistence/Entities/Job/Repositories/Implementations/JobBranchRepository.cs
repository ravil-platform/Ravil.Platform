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
       
        var jobBranchList = ApplicationDbContext.JobBranch.AsNoTracking()
            .Where(a => a.IsDeleted != null && !a.IsDeleted.Value)
            .Where(a => a.Job.Status == JobBranchStatus.Accepted);

        var relatedCities = await ApplicationDbContext.JobBranchRelatedJob.AsNoTracking()
            .Where(j => j.CurrentCityId == cityId)
            .OrderBy(j => j.Sort)
            .ToListAsync();

        if (relatedCities.Any())
        {
            foreach (var relatedCity in relatedCities)
            {
                var jobBranchQueryable = ApplicationDbContext.Address.Include(a => a.Location)
                    .Include(c => c.JobBranch)
                    .Include(a => a.JobBranch.Job)
                    .Include(a => a.JobBranch.JobBranchGalleries)
                    .Where(a => a.JobBranch.IsDeleted != null && !a.JobBranch.IsDeleted.Value)
                    .Where(a => a.JobBranch.Job.Status == JobBranchStatus.Accepted)
                    .Where(a => a.CityId == relatedCity.DisplayedCityId || a.CityId == relatedCity.CurrentCityId).Select(a => a.JobBranch);

                jobBranchList = take > 0 ? jobBranchQueryable.Where(j => jobIds.Contains(j.JobId)).Take(take) 
                    : jobBranchQueryable.Where(j => jobIds.Contains(j.JobId));

                //jobBranch = jobBranch
                //    .Include(s => s.Job)
                //    .Include(s => s.Address)
                //    .ThenInclude(s => s.Location)
                //    .Include(s => s.JobBranchGalleries)
                //    .Where(j => j.Address.CityId == relatedCity.DisplayedCityId && jobIds.Contains(j.JobId)).Take(take);
            }
        }
        else
        {
            jobBranchList = jobBranchList.Include(a => a.Job)
                .Include(a => a.JobBranchGalleries)
                .Include(a => a.Address).ThenInclude(a => a.Location)
                .Where(j => jobIds.Contains(j.JobId));
        }

        return jobBranchList;
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