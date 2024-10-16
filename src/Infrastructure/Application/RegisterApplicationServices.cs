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

            services.AddIdentityService();
        }


        public static IdentityBuilder AddIdentityService(this IServiceCollection services)
        {
            #region ( Identity )

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;

                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters = "0123456789";

                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedPhoneNumber = true;

                options.Lockout.AllowedForNewUsers = true;
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);

                options.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultPhoneProvider;
                options.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultEmailProvider;
                options.Tokens.ChangeEmailTokenProvider = TokenOptions.DefaultEmailProvider;

            }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            #region Set Cookie options

            services.ConfigureApplicationCookie(options =>
            {
                options.SlidingExpiration = true;
                options.Cookie.HttpOnly = true;
                options.Cookie.SameSite = SameSiteMode.Unspecified;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(720);
                options.LogoutPath = $"/account/sign-out";
                options.LoginPath =  $"/account/sign-in";
                options.AccessDeniedPath = $"/account/access-denied";
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
            });

            services.Configure<PasswordHasherOptions>(option =>
            {
                option.IterationCount = 12000;
            });

            #endregion

            return new IdentityBuilder(typeof(ApplicationUser), typeof(IdentityRole), services);

            #endregion
        }
    }
}
