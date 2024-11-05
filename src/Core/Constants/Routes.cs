namespace Constants
{
    public static class Routes
    {
        static Routes()
        {

        }

        public static string SetApiVersion(string versionNumber)
        {
            return ApiVersion + versionNumber;
        }

        public static string CreateRouteWithVersion(string versionNumber)
        {
            return $"{Base}/{SetApiVersion(versionNumber)}/[controller]";
        }

        public const string Base = "api";
        public const string Action = "[action]";
        public const string ControllerBase = "[controller]";
        public const string ApiVersion = "v{version:apiVersion}";
        public const string Controller = $"{Base}/{ApiVersion}/[controller]";
    }
}
