using ViewModels.AdminPanel.Filter;
using ViewModels.Filter.User;

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

    public async Task<bool> JobRouteExist(string route)
    {
        return await ApplicationDbContext.Job.AnyAsync(j => j.Route == route.ToSlug());
    }

    public async Task<bool> JobBranchRouteExist(string route)
    {
        return await ApplicationDbContext.Job.AnyAsync(j => j.Route == route.ToSlug());
    }

    public async Task SetIsDelete(int jobId, bool delete)
    {
        var job = await ApplicationDbContext.Job.SingleOrDefaultAsync(j => j.Id == jobId);

        if (job != null)
        {
            job.IsDeleted = delete;
        }
    }

    public JobFilterViewModel GetByAdminFilter(JobFilterViewModel filter)
    {
        var query =
           ApplicationDbContext.Job
               // .Where(b => b.Status == JobBranchStatus.Accepted)
               .OrderByDescending(b => b.CreateDate)
               .AsQueryable();

        if (filter.FindAll)
        {
            #region (Find All)
            filter.Build(query.Count()).SetEntities(query);

            return filter;
            #endregion
        }

        #region (Filter)
        if (!string.IsNullOrWhiteSpace(filter.Route))
        {
            query = query.Where(a => a.Route.Contains(filter.Route.ToSlug().Trim()));
        }

        if (!string.IsNullOrWhiteSpace(filter.Title))
        {
            query = query.Where(a => a.Title.Contains(filter.Title.Trim()));
        }

        if (!string.IsNullOrWhiteSpace(filter.SubTitle))
        {
            query = query.Where(a => a.SubTitle.Contains(filter.SubTitle.Trim()));
        }

        if (!string.IsNullOrWhiteSpace(filter.Summary))
        {
            query = query.Where(a => a.Summary.Contains(filter.Summary.Trim()));
        }

        if (!string.IsNullOrWhiteSpace(filter.Content))
        {
            query = query.Where(a => a.Content.Contains(filter.Content.Trim()));
        }

        if (filter.Status != null)
        {
            query = query.Where(a => a.Status == filter.Status);
        }
        else
        {
            query = query.Where(a => a.Status == JobBranchStatus.Accepted);
        }

        if (filter.IsDeleted != null)
        {
            query = query.Where(a => a.IsDeleted == filter.IsDeleted);
        }
        else
        {
            query = query.Where(a => a.IsDeleted == false);
        }

        if (filter.IsGoogleData != null)
        {
            query = query.Where(a => a.IsGoogleData == filter.IsGoogleData);
        }

        if (filter.HasNotAnyJobBranches != null)
        {
            query = query.Include(j => j.JobBranches).Where(j => j.JobBranches.Count == 0);
        }

        if (filter.SortedBy != null)
        {
            switch (filter.SortedBy)
            {
                case JobSortedBy.Newest:
                    query = query.OrderByDescending(j => j.CreateDate);
                    break;
                case JobSortedBy.Oldest:
                    query = query.OrderBy(j => j.CreateDate);
                    break;
            }
        }


        try
        {
            if (filter.CreatedDateFrom != null)
            {
                var persianCalendar = new PersianCalendar();

                var year = filter.CreatedDateFrom.Value.Year;
                var month = filter.CreatedDateFrom.Value.Month;
                var day = filter.CreatedDateFrom.Value.Day;

                var createdDateFrom = persianCalendar.ToDateTime(year, month, day, 00, 00, 00, 00);

                query = query.Where(a => a.CreateDate >= createdDateFrom);
            }

            if (filter.CreatedDateTo != null)
            {
                var persianCalendar = new PersianCalendar();

                var year = filter.CreatedDateTo.Value.Year;
                var month = filter.CreatedDateTo.Value.Month;
                var day = filter.CreatedDateTo.Value.Day;

                var createdDateTo = persianCalendar.ToDateTime(year, month, day, 23, 59, 59, 59);

                query = query.Where(a => a.CreateDate <= createdDateTo);
            }
        }
        catch
        {

        }

        #endregion

        filter.Build(query.Count()).SetEntities(query);

        return filter;
    }
}