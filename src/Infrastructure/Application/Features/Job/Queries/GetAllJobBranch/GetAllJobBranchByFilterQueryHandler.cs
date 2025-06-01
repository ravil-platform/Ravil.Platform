using Constants.Caching;
using Resources.Messages;
using AutoMapper.QueryableExtensions;
using Microsoft.Extensions.Caching.Distributed;

namespace Application.Features.Job.Queries.GetAllJobBranch;

public class GetAllJobBranchByFilterQueryHandler(IMapper mapper,
    IUnitOfWork unitOfWork, IDistributedCache distributedCache)
: IRequestHandler<GetAllJobBranchByFilterQuery, JobBranchFilter>
{
    #region ( Dependencies )

    protected JobBranchFilter JobBranchFilter { get; set; }

    protected IMapper Mapper { get; } = mapper;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected IDistributedCache DistributedCache { get; } = distributedCache;

    #endregion

    public async Task<Result<JobBranchFilter>> Handle(GetAllJobBranchByFilterQuery request, CancellationToken cancellationToken)
    {
        #region ( Get All JobBranch By Filter Query )

        request.Step ??= 24;
        JobBranchFilter = Mapper.Map<JobBranchFilter>(request);

        JobBranchFilter = await DistributedCache.GetOrSet(key: CacheKeys.GetAllJobBranchByFilterQuery(request.CityId, request.CategoryId),
            func: async () =>
            {
                #region ( JobBranchFilter Data )

                List<int> jobsId = new ();
                var category = await UnitOfWork.CategoryRepository.TableNoTracking
                    .Where(j => j.Id == request.CategoryId)
                    .SingleOrDefaultAsync(cancellationToken: cancellationToken);

                if (category is null)
                {
                    if (category is { NodeLevel: 2 })
                    {
                        jobsId = await UnitOfWork.JobCategoryRepository.TableNoTracking.Include(a => a.Category)
                            .Where(j => j.Category.ParentId == request.CategoryId)
                            .OrderBy(a => a.Category.Sort).Select(a => a.JobId)
                            .ToListAsync(cancellationToken: cancellationToken);
                    }
                    else
                    {
                        jobsId = await UnitOfWork.JobCategoryRepository.TableNoTracking
                            .Where(j => j.CategoryId == request.CategoryId)
                            .Select(a => a.JobId).ToListAsync(cancellationToken: cancellationToken);
                    }
                }

                var jobKeywords = await UnitOfWork.JobKeywordRepository.TableNoTracking
                    .Include(a => a.Keyword).Include(a => a.JobBranch)
                    .Where(a => a.Keyword.CategoryId == request.CategoryId).ToListAsync(cancellationToken: cancellationToken);

                if (jobKeywords.Any())
                {
                    jobsId.AddRange(jobKeywords.Select(a => a.JobBranch.JobId).ToList());
                }

                var baseJobsId = jobsId.Distinct().ToList();
                var jobBranchQuery = UnitOfWork.JobBranchRepository.TableNoTracking.Include(a => a.JobKeywords)
                    //.Include(a => a.ApplicationUser).ThenInclude(a => a.UserSubscriptions.Where(s => s.IsActive && s.IsFinally && s.EndDate.Day >= DateTime.UtcNow.Day)).ThenInclude(a => a.Subscription)
                    .Include(a => a.Job).Include(a => a.JobBranchGalleries)
                    .Include(a => a.Address).ThenInclude(a => a.Location)
                    .Where(a => a.Status == JobBranchStatus.Accepted || a.Job.Status == JobBranchStatus.Accepted)
                    .Where(a => baseJobsId.Contains(a.JobId) && a.Address.CityId.Equals(request.CityId))
                    .Where(a => a.IsDeleted != null && !a.IsDeleted.Value)
                    .AsQueryable();

                JobBranchFilter.Build(jobBranchQuery.Count()).SetEntities(jobBranchQuery, Mapper, hasNoPagination: true);

                #region ( DetectIsAdsJobs )

                foreach (var current in JobBranchFilter.DtoEntities)
                {
                    var currentActiveUserSubscription = await UnitOfWork.UserSubscriptionRepository.TableNoTracking.Include(a => a.Subscription)
                        .Where(a => !string.IsNullOrWhiteSpace(current.UserId) && a.UserId == current.UserId)
                        .Where(a => a.IsActive && a.IsFinally && a.EndDate.Day >= DateTime.UtcNow.Day)
                        .OrderByDescending(currentSub => currentSub.StartDate)
                        .FirstOrDefaultAsync(cancellationToken: cancellationToken);

                    if (current.Keywords != null && currentActiveUserSubscription is not null)
                    {
                        var jobKeywordsId = jobKeywords.Select(a => a.KeywordId).ToList();
                        var currentKeywordsId = current.Keywords.Select(a => a.Id).ToList();

                        if (jobKeywordsId.Intersect(currentKeywordsId).Any())
                        {
                            current.IsAds = true;
                            current.SubscriptionType = currentActiveUserSubscription.Subscription.Type;
                        }
                        else
                        {
                            current.IsAds = false;
                            current.SubscriptionType = SubscriptionType.Simple;
                        }
                    }
                    else
                    {
                        current.IsAds = false;
                        current.SubscriptionType = SubscriptionType.Simple;
                    }
                }

                #endregion

                #region ( When Afew Jobs )

                if (JobBranchFilter.EntitiesCount < 24)
                {
                    var relatedCities = await UnitOfWork.JobBranchRelatedJobRepository.TableNoTracking.AsNoTracking()
                        .Where(j => j.CurrentCityId == request.CityId)
                        .OrderBy(j => j.Sort)
                        .ToListAsync(cancellationToken: cancellationToken);

                    if (relatedCities.Any())
                    {
                        foreach (var relatedCity in relatedCities)
                        {
                            var take = 24 - JobBranchFilter.EntitiesCount;

                            var jobBranchRelatedCities = await UnitOfWork.AddressRepository.TableNoTracking
                                .Include(a => a.Location)
                                .Include(c => c.JobBranch)
                                .Include(a => a.JobBranch.Job)
                                .Include(a => a.JobBranch.JobBranchGalleries)
                                .Where(j => jobsId.Distinct().Contains(j.JobBranch.JobId))
                                .Where(a => a.JobBranch.IsDeleted != null && !a.JobBranch.IsDeleted.Value)
                                .Where(a => a.JobBranch.Status == JobBranchStatus.Accepted || a.JobBranch.Job.Status == JobBranchStatus.Accepted)
                                .Where(a => a.CityId == relatedCity.DisplayedCityId || a.CityId == relatedCity.CurrentCityId).Select(a => a.JobBranch)
                                .Take(take).ProjectTo<JobBranchViewModel>(Mapper.ConfigurationProvider)
                                .ToListAsync(cancellationToken: cancellationToken);

                            JobBranchFilter.DtoEntities.AddRange(jobBranchRelatedCities);
                            JobBranchFilter.EntitiesCount = JobBranchFilter.DtoEntities.Count;
                        }
                    }
                    else
                    {
                        var take = 24 - JobBranchFilter.EntitiesCount;

                        int parentId = category.Id;
                        if (category.NodeLevel != 2)
                        {
                            parentId = await UnitOfWork.CategoryRepository.TableNoTracking
                                .Where(j => j.Id == request.CategoryId)
                                .Select(a => a.ParentId)
                                .FirstOrDefaultAsync(cancellationToken: cancellationToken);
                        }

                        var relatedCategoryJobsId = await UnitOfWork.JobCategoryRepository.TableNoTracking
                            .Include(a => a.Category)
                            .Where(j => j.CategoryId != request.CategoryId && j.Category.ParentId.Equals(parentId))
                            .Select(a => a.JobId)
                            .ToListAsync(cancellationToken: cancellationToken);

                        if (relatedCategoryJobsId.Any())
                        {
                            jobsId = jobsId.Concat(relatedCategoryJobsId).Distinct().ToList();

                            var jobBranchRelatedCategories = await UnitOfWork.JobBranchRepository.TableNoTracking
                                .Include(a => a.Job).Include(a => a.JobBranchGalleries)
                                .Include(a => a.Address).ThenInclude(a => a.Location)
                                .Where(a => a.Status == JobBranchStatus.Accepted || a.Job.Status == JobBranchStatus.Accepted)
                                .Where(a => a.IsDeleted != null && !a.IsDeleted.Value)
                                .Where(a => jobsId.Distinct().Contains(a.JobId))
                                .Take(take).ProjectTo<JobBranchViewModel>(Mapper.ConfigurationProvider)
                                .ToListAsync(cancellationToken: cancellationToken);

                            JobBranchFilter.DtoEntities.AddRange(jobBranchRelatedCategories);
                            JobBranchFilter.EntitiesCount = JobBranchFilter.DtoEntities.Count;
                        }
                    }
                }

                #endregion

                return await Task.FromResult(JobBranchFilter);

                #endregion
            },
            options: new DistributedCache.CacheOptions
            {
                ExpireSlidingCacheFromMinutes = 4 * 60,
                AbsoluteExpirationCacheFromMinutes = 24 * 60
            });


        if (JobBranchFilter is null)
            return Result.Fail(Validations.NotFoundException);

        return await Task.FromResult(JobBranchFilter);

        #endregion
    }
}