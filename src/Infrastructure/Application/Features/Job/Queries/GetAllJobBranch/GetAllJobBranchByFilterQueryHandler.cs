using AutoMapper.QueryableExtensions;

namespace Application.Features.Job.Queries.GetAllJobBranch;

public class GetAllJobBranchByFilterQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    : IRequestHandler<GetAllJobBranchByFilterQuery, JobBranchFilter>
{
    #region ( Dependencies )

    protected JobBranchFilter JobBranchFilter { get; set; }
    protected IMapper Mapper { get; } = mapper;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;

    #endregion

    public async Task<Result<JobBranchFilter>> Handle(GetAllJobBranchByFilterQuery request, CancellationToken cancellationToken)
    {
        request.Step ??= 24;
        JobBranchFilter = Mapper.Map<JobBranchFilter>(request);

        List<int> jobsId;
        var category = await UnitOfWork.CategoryRepository.TableNoTracking
            .Where(j => j.Id == request.CategoryId)
            .SingleOrDefaultAsync(cancellationToken: cancellationToken);

        if (category is null)
            return Result.Fail(Resources.Messages.Validations.NotFoundException);

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

        var jobKeywords = await UnitOfWork.JobKeywordRepository.TableNoTracking
            .Include(a => a.Keyword).Include(a => a.JobBranch)
            .Where(a => a.Keyword.CategoryId == request.CategoryId).ToListAsync(cancellationToken: cancellationToken);

        if (jobKeywords.Any())
        {
            jobsId.AddRange(jobKeywords.Select(a => a.JobBranch.JobId).ToList());
        }

        var baseJobsId = jobsId.Distinct().ToList();
        var jobBranchQuery = UnitOfWork.JobBranchRepository.TableNoTracking
            .Include(a => a.ApplicationUser).ThenInclude(a => a.UserSubscriptions.Where(s => s.IsActive && s.IsFinally && s.EndDate.Day >= DateTime.UtcNow.Day)).ThenInclude(a => a.Subscription)
            .Include(a => a.Job).Include(a => a.JobBranchGalleries)
            .Include(a => a.Address).ThenInclude(a => a.Location)
            .Where(a => a.Status == JobBranchStatus.Accepted || a.Job.Status == JobBranchStatus.Accepted)
            .Where(a => baseJobsId.Contains(a.JobId) && a.Address.CityId.Equals(request.CityId))
            .Where(a => a.IsDeleted != null && !a.IsDeleted.Value)
            .AsQueryable();
        
        JobBranchFilter.Build(jobBranchQuery.Count()).SetEntities(jobBranchQuery, Mapper, hasNoPagination: true);

        #region ( DetectIsAdsJobs )

        //JobBranchFilter.DtoEntities.ForEach(DetectIsAdsJobs);
        /*foreach (var current in JobBranchFilter.DtoEntities)
        {
            var currentActiveUserSubscription = await UnitOfWork.UserSubscriptionRepository.TableNoTracking.Include(a => a.Subscription)
                .Where(a => !string.IsNullOrWhiteSpace(current.UserId) && a.UserId == current.UserId)
                .Where(a => a.IsActive && a.IsFinally && a.EndDate.Day >= DateTime.UtcNow.Day)
                .SingleOrDefaultAsync(cancellationToken: cancellationToken);

            if (currentActiveUserSubscription is not null)
            {
                current.IsAds = true;
                current.SubscriptionType = currentActiveUserSubscription.Subscription.Type;
            }
            else
            {
                current.IsAds = false;
                current.SubscriptionType = SubscriptionType.Simple;
            }
        }*/

        #endregion

        #region ( When Afew Jobs )

        if (JobBranchFilter.EntitiesCount < 20)
        {
            var relatedCities = await UnitOfWork.JobBranchRelatedJobRepository.TableNoTracking.AsNoTracking()
                .Where(j => j.CurrentCityId == request.CityId)
                .OrderBy(j => j.Sort)
                .ToListAsync(cancellationToken: cancellationToken);

            if (relatedCities.Any())
            {
                foreach (var relatedCity in relatedCities)
                {
                    var take = 20 - JobBranchFilter.EntitiesCount;

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
                }
            }
            else
            {
                var take = 20 - JobBranchFilter.EntitiesCount;

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
                }
            }
        }

        #endregion


        return await Task.FromResult(JobBranchFilter);
    }
}