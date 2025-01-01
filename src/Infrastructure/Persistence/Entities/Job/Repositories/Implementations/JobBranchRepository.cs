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
       
        var jobBranch = ApplicationDbContext.JobBranch.AsQueryable();

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
}