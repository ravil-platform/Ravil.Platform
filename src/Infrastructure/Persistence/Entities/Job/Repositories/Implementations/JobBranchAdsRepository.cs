﻿using ViewModels.AdminPanel.Filter;

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
        var jobBranchIds = await ApplicationDbContext.JobBranchAds.Select(j => j.JobBranchId).Distinct().ToListAsync();

        var data = new List<JobBranch>();

        foreach (var jobBranchId in jobBranchIds)
        {
            var jobBranch = await ApplicationDbContext.JobBranch.AsNoTracking()
                .Include(current => current.JobTimeWorks)
                .Include(current => current.JobBranchGalleries)
                .Include(current => current.Address).ThenInclude(current => current.Location)
                .Include(current => current.Job).ThenInclude(current => current.JobCategories).ThenInclude(current => current.Category)
                .Where(j => j.Id == jobBranchId)
                .Where(a => a.IsDeleted != null && !a.IsDeleted.Value)
                .Where(a => a.Job.Status == JobBranchStatus.Accepted)
                .SingleOrDefaultAsync();

            if (jobBranch != null)
            {
                data.Add(jobBranch);
            }
        }

        return data;
    }

    public JobBranchAdsFilterViewModel GetByFilterAdmin(JobBranchAdsFilterViewModel filter)
    {
        var query = ApplicationDbContext.JobBranchAds.AsQueryable();

        if (filter.FindAll)
        {
            #region (Find All)
            filter.Build(query.Count()).SetEntities(query);

            return filter;
            #endregion
        }

        #region ( Filter )
        if (!string.IsNullOrWhiteSpace(filter.JobBranchName))
        {
            query = query.Where(q => q.JobBranchName.Contains(filter.JobBranchName));
        }
        #endregion

        filter.Build(query.Count()).SetEntities(query);

        return filter;
    }
}