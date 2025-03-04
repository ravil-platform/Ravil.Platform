using System.Collections.Generic;
using AutoMapper.QueryableExtensions;

namespace Application.Features.Job.Queries.GetAllJobBranch;

public class GetAllJobBranchByFilterQueryHandler : IRequestHandler<GetAllJobBranchByFilterQuery, JobBranchFilter>
{
    protected JobBranchFilter JobBranchFilter { get; set; }
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }
    public GetAllJobBranchByFilterQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<JobBranchFilter>> Handle(GetAllJobBranchByFilterQuery request, CancellationToken cancellationToken)
    {
        request.Step ??= 24;
        JobBranchFilter = Mapper.Map<JobBranchFilter>(request);

        var jobsId = await UnitOfWork.JobCategoryRepository.TableNoTracking
            .Where(j => j.CategoryId == request.CategoryId)
            .Select(a => a.JobId)
            .ToListAsync(cancellationToken: cancellationToken);
        
        var baseJobsId = jobsId.Distinct();
        var jobBranchQuery = UnitOfWork.JobBranchRepository.TableNoTracking
            .Include(a => a.Job).Include(a => a.JobBranchGalleries)
            .Include(a => a.Address).ThenInclude(a => a.Location)
            .Where(a => a.IsDeleted != null && !a.IsDeleted.Value)
            .Where(a => a.Job.Status == JobBranchStatus.Accepted)
            .Where(a => baseJobsId.Contains(a.JobId) && a.Address.CityId.Equals(request.CityId))
            .AsQueryable();

        JobBranchFilter.Build(jobBranchQuery.Count()).SetEntities(jobBranchQuery, Mapper);

        if (JobBranchFilter.EntitiesCount < 20)
        {
            var relatedCities = await UnitOfWork.JobBranchRelatedJobRepository.TableNoTracking.AsNoTracking()
                .Where(j => j.CurrentCityId == request.CityId)
                .OrderBy(j => j.Sort)
                .ToListAsync(cancellationToken);

            if (relatedCities.Any())
            {
                foreach (var relatedCity in relatedCities)
                {
                    var take = 20 - JobBranchFilter.EntitiesCount;

                    var jobBranchRelatedCities = await UnitOfWork.AddressRepository.TableNoTracking.Include(a => a.Location)
                        .Include(c => c.JobBranch)
                        .Include(a => a.JobBranch.Job)
                        .Include(a => a.JobBranch.JobBranchGalleries)
                        .Where(a => a.JobBranch.IsDeleted != null && !a.JobBranch.IsDeleted.Value)
                        .Where(a => a.JobBranch.Job.Status == JobBranchStatus.Accepted)
                        .Where(j => jobsId.Distinct().Contains(j.JobBranch.JobId))
                        .Where(a => a.CityId == relatedCity.DisplayedCityId || a.CityId == relatedCity.CurrentCityId).Select(a => a.JobBranch)
                        .Take(take)
                        .ProjectTo<JobBranchViewModel>(Mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken);

                    JobBranchFilter.DtoEntities.AddRange(jobBranchRelatedCities);
                }
            }
            else
            {
                var take = 20 - JobBranchFilter.EntitiesCount;

                var parentId = await UnitOfWork.CategoryRepository.TableNoTracking
                    .Where(j => j.Id == request.CategoryId)
                    .Select(a => a.ParentId)
                    .FirstOrDefaultAsync(cancellationToken: cancellationToken);

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
                        .Where(a => a.IsDeleted != null && !a.IsDeleted.Value)
                        .Where(a => a.Job.Status == JobBranchStatus.Accepted)
                        .Where(a => jobsId.Distinct().Contains(a.JobId))
                        .Take(take).ProjectTo<JobBranchViewModel>(Mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken);

                    JobBranchFilter.DtoEntities.AddRange(jobBranchRelatedCategories);
                }
            }
        }


        return await Task.FromResult(JobBranchFilter);
    }
}