using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json.Linq;

namespace Application.Features.Job.Queries.GetRecommendationJob
{
    public class GetRecommendationJobCommandHandler(IMapper mapper,
        IUnitOfWork unitOfWork, IDistributedCache distributedCache,
        HttpClient httpClient)
        : IRequestHandler<GetRecommendationJobCommand, List<JobBranchViewModel>>
    {

        #region ( Dependencies )
        protected IMapper Mapper { get; } = mapper;
        protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
        protected IDistributedCache DistributedCache { get; } = distributedCache;
        protected HttpClient HttpClient { get; } = httpClient;

        #endregion
        
        public async Task<Result<List<JobBranchViewModel>>> Handle(GetRecommendationJobCommand request, CancellationToken cancellationToken)
        {
            var userName = await UnitOfWork.ApplicationUserRepository.TableNoTracking
                .Where(u => u.Id == request.UserId)
                .Select(u => u.UserName)
                .SingleOrDefaultAsync(cancellationToken);

            if (userName is null) return new Result<List<JobBranchViewModel>>();

            var requestData = new
            {
                user_id = userName,
                fav_job_title = request.JobTitle,
                n_recommendations = 8
            };

            var json = JsonConvert.SerializeObject(requestData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await HttpClient.PostAsync(RequestUri.Recommend, content, cancellationToken);

            var result = new Result<List<JobBranchViewModel>>();

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);

                if (string.IsNullOrWhiteSpace(responseContent))
                    return new Result<List<JobBranchViewModel>>();

                JObject? obj;
                try
                {
                    obj = JObject.Parse(responseContent);
                }
                catch (JsonReaderException)
                {
                    return new Result<List<JobBranchViewModel>>();
                }

                var recommendationsToken = obj["recommendations"];
                if (recommendationsToken is null || !recommendationsToken.Any())
                    return new Result<List<JobBranchViewModel>>();

                var jobIds = recommendationsToken
                    .Select(token => (int?)token)
                    .Where(id => id.HasValue)
                    .Select(id => id!.Value)
                    .ToList();

                if (!jobIds.Any())
                    return new Result<List<JobBranchViewModel>>();

                var jobBranches = await UnitOfWork.JobBranchRepository.GetJobBranchByJobId(jobIds, cancellationToken);

                result = Mapper.Map<List<JobBranchViewModel>>(jobBranches);

                return result;
            }

            return result;
        }
    }
}
