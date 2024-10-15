namespace Application
{
    public static class RegisterApplicationServices
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();

            services.AddMediatR(options =>
            {
                options.RegisterServicesFromAssembly(typeof(BaseController).GetTypeInfo().Assembly);
            });

            services.AddAutoMapper(typeof(MappingProfile));
            services.AddTransient(serviceType: typeof(Logging.Base.ILogger<>), implementationType: typeof(NLogAdapter<>));

            var siteSettingConfiguration = configuration.GetSection(nameof(SiteSettings));
            services.Configure<IOptions<SiteSettings>>(siteSettingConfiguration);
        }
    }
}
