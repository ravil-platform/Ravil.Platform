using System.Text.RegularExpressions;
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

    public async Task<List<Domain.Entities.Job.Job>> SearchJob(string? title = null, string? city = null)
    {
        var jobs = new List<Domain.Entities.Job.Job>();

        try
        {

            if (city == null && title != null)
            {
                jobs = await ApplicationDbContext.Job.AsNoTracking()
                    .Where(j => EF.Functions.Like(j.SubTitle, $"%{title}%")
                        || EF.Functions.Like(j.Summary, $"%{title}%")
                        || EF.Functions.Like(j.Title, $"%{title}%")
                        && j.Status == JobBranchStatus.Accepted)
                    .Select(j => new Domain.Entities.Job.Job
                    {
                        Route = j.Route.ToSlug(),
                        Title = j.Title,
                        SubTitle = j.SubTitle,
                    })
                    .Take(20).ToListAsync();
            }
            else
            {
                var query = ApplicationDbContext.Address
                    .Include(a => a.City).Include(a => a.State)
                    .Include(a => a.JobBranch)
                    .ThenInclude(j => j.Job)
                    .ThenInclude(a => a.JobCategories)
                    .ThenInclude(a => a.Category)
                    .Where(a =>
                        EF.Functions.Like(a.City.Name, $"%{city}%")
                        || EF.Functions.Like(a.State.Name, $"%{city}%")
                        || EF.Functions.Like(a.Neighbourhood, $"%{city}%")
                        || EF.Functions.Like(a.OtherAddress, $"%{city}%")
                        || EF.Functions.Like(a.PostalAddress, $"%{city}%"))
                    .AsQueryable();

                if (title != null)
                {
                    jobs = await query.Where(j => (EF.Functions.Like(j.JobBranch.Job.Title, $"%{title}%")
                        || EF.Functions.Like(j.JobBranch.Job.SubTitle, $"%{title}%")
                        || EF.Functions.Like(j.JobBranch.Job.Summary, $"%{title}%")
                        || (j.JobBranch.Job.JobCategories.Any() && EF.Functions.Like(j.JobBranch.Job.JobCategories.First().Category.Name, $"%{title}%"))
                        || (j.JobBranch.Job.JobCategories.Any() && EF.Functions.Like(j.JobBranch.Job.JobCategories.First().Category.HeadingTitle, $"%{title}%"))
                        || (j.JobBranch.Job.JobCategories.Any() && EF.Functions.Like(j.JobBranch.Job.JobCategories.First().Category.PageContent, $"%{title}%")))
                        && j.JobBranch.Job.Status == JobBranchStatus.Accepted && j.JobBranch.Job.IsDeleted == false)
                    .Select(a => new Domain.Entities.Job.Job
                    {
                        Route = a.JobBranch.Job.Route,
                        Title = a.JobBranch.Job.Title,
                        SubTitle = a.JobBranch.Job.SubTitle,
                        Status = a.JobBranch.Job.Status,
                        JobCategories = a.JobBranch.Job.JobCategories,
                    })
                    .Take(20).ToListAsync();
                }
                else
                {
                    jobs = await query.Select(a => new Domain.Entities.Job.Job
                    {
                        Route = a.JobBranch.Job.Route,
                        Title = a.JobBranch.Job.Title,
                        SubTitle = a.JobBranch.Job.SubTitle,
                        Status = a.JobBranch.Job.Status,
                        JobCategories = a.JobBranch.Job.JobCategories,
                    }).Take(20).ToListAsync();
                }
            }
        }
        catch
        {
            throw;
        }


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
           ApplicationDbContext.Job.Include(j => j.JobBranches)
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
        //else
        //{
        //    query = query.Where(a => a.Status == JobBranchStatus.Accepted);
        //}

        if (filter.IsDeleted != null)
        {
            query = query.Where(a => a.IsDeleted == filter.IsDeleted);
        }
        //else
        //{
        //    query = query.Where(a => a.IsDeleted == false);
        //}

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

        if (filter.IsDuplicate != null && filter.IsDuplicate == true)
        {
            var duplicateJobIds = ApplicationDbContext.Job
                .AsNoTracking()
                .Select(j => new { j.Id, j.Title, j.Route })
                .ToList()
                .GroupBy(j => new { j.Title, j.Route })
                .Where(g => g.Count() > 1)
                .SelectMany(g => g.Select(j => j.Id))
                .ToList();

            query = query.Where(j => duplicateJobIds.Contains(j.Id));
        }

        if (filter.IsEnglishOnly != null && filter.IsEnglishOnly == true)
        {
            query = query
                .AsEnumerable()
                .Where(j => Regex.IsMatch(j.Title ?? "", "^[a-zA-Z0-9\\s]+$"))
                .AsQueryable();
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