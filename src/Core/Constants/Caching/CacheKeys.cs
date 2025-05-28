
namespace Constants.Caching
{
    public static class CacheKeys
    {
        public static string GetJobStatisticsByFilterQuery(int jobId, string fromDate, string toDate) => $"{nameof(GetJobStatisticsByFilterQuery)}-{jobId}-{fromDate}-{toDate}";
        public static string GetJobRankingsByFilterQuery(int jobId, string fromDate, string toDate) => $"{nameof(GetJobRankingsByFilterQuery)}-{jobId}-{fromDate}-{toDate}";
        public static string GetAllJobBranchByFilterQuery(int cityId, int categoryId) => $"{nameof(GetAllJobBranchByFilterQuery)}-{cityId}-{categoryId}";
        public static string GetUserSubscriptionPlanQuery(string userId) => $"{nameof(GetUserSubscriptionPlanQuery)}-{userId}";
        public static string GetJobStatisticsByFilterQuery(int jobId) => $"{nameof(GetJobStatisticsByFilterQuery)}-{jobId}";
        public static string GetJobRankingsByFilterQuery(int jobId) => $"{nameof(GetJobRankingsByFilterQuery)}-{jobId}";
        public static string GetJobBranchByRouteQuery(string route) => $"{nameof(GetJobBranchByRouteQuery)}-{route}";
        public static string GetReviewsSummeryQuery(string jobId) => $"{nameof(GetReviewsSummeryQuery)}-{jobId}";
        public static string GetContactRequestsQuery(int jobId) => $"{nameof(GetContactRequestsQuery)}-{jobId}";
        public static string GetTagsPotentialQuery(int jobId) => $"{nameof(GetTagsPotentialQuery)}-{jobId}";
        public static string GetJobBranchByIdQuery(string id) => $"{nameof(GetJobBranchByIdQuery)}-{id}";
        public static string GetRelatedJobsQuery(int jobId) => $"{nameof(GetRelatedJobsQuery)}-{jobId}";
        public static string GetAllSubscriptionPlanQuery() => $"{nameof(GetAllSubscriptionPlanQuery)}";
        public static string GetJobViewsQuery(int jobId) => $"{nameof(GetJobViewsQuery)}-{jobId}";
        public static string JobOverViewQuery(int jobId) => $"{nameof(JobOverViewQuery)}-{jobId}";
        public static string GetUserByIdQuery(string id) => $"{nameof(GetUserByIdQuery)}-{id}";
        public static string JobReportQuery(int jobId) => $"{nameof(JobReportQuery)}-{jobId}";
        public static string GetAllCategoriesQuery() => $"{nameof(GetAllCategoriesQuery)}";
        public static string GetAllKeywordsQuery() => $"{nameof(GetAllKeywordsQuery)}";
        public static string GetNewestJobsQuery() => $"{nameof(GetNewestJobsQuery)}";
        public static string GetAllCitiesQuery() => $"{nameof(GetAllCitiesQuery)}";
        public static string GetBestJobsQuery() => $"{nameof(GetBestJobsQuery)}";
        public static string GetAllBlogsQuery() => $"{nameof(GetAllBlogsQuery)}";
        public static string GetAllJobsQuery() => $"{nameof(GetAllJobsQuery)}";
        public static string GetConfigQuery() => $"{nameof(GetConfigQuery)}";
    }
}
