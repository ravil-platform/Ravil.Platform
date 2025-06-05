using Microsoft.AspNetCore.Authentication.JwtBearer;
using Application.BackgroundServices;
using Application.Services.NehsanApi;
using StackExchange.Redis;
using ZarinPalDriver;
using Hangfire;

namespace Application
{
    public static class RegisterApplicationServices
    {
        
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment, JwtSettings? jwtSettings = null, RedisCacheOptions? redisCacheOptions = null)
        {
            #region ( Caching Services )

            //services.AddMemoryCache();
            //services.AddDistributedMemoryCache();
            services.AddStackExchangeRedisCache(options =>
            {
                if (redisCacheOptions != null)
                {
                    var configurationRedisCache = ConfigurationOptions.Parse(redisCacheOptions.ConnectionString ?? $"{redisCacheOptions.IpAddress}:{redisCacheOptions.Port}");
                    configurationRedisCache.Password = redisCacheOptions.Password;

                    options.ConfigurationOptions = configurationRedisCache;
                }
                else
                {
                    var configurationRedisCache = ConfigurationOptions.Parse("62.60.164.61:6379");
                    configurationRedisCache.Password = "qwe123$$QWE";  // وارد کردن پسورد Redis

                    options.ConfigurationOptions = configurationRedisCache;
                }
            });

            //services.AddSingleton<IConnectionMultiplexer>(sp =>
            //    ConnectionMultiplexer.Connect("62.60.210.251")
            //);

            #endregion

            services.AddHttpContextAccessor();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            services.AddMediatR(options =>
            {
                options.RegisterServicesFromAssembly(typeof(BaseController).GetTypeInfo().Assembly);
            });

            services.AddAutoMapper(typeof(MappingProfile));

            if (environment.IsProduction())
            {
                NLog.LogManager.Configuration.Variables["rootDir"] = AppDomain.CurrentDomain.BaseDirectory;
            }
            else
            {
                NLog.LogManager.Configuration.Variables["rootDir"] = @"C:\Temp\NewtanLogs\";
            }
            services.AddTransient(serviceType: typeof(Logging.Base.ILogger<>), implementationType: typeof(NLogAdapter<>));

            var siteSettingConfiguration = configuration.GetSection(nameof(SiteSettings));
            services.Configure<IOptions<SiteSettings>>(siteSettingConfiguration);

            services.AddIdentityService();

            services.AddValidatorsFromAssemblyContaining<CreateUserCommandValidator>();

            services.AddTransient(typeof(MediatR.IPipelineBehavior<,>), typeof(RNX.Mediator.ValidationBehavior<,>));

            services.AddTransient<JwtCustomValidation>();
            services.AddTransient<IJwtService, JwtService>();
            services.AddTransient<ISmsSender, SmsSender>();
            services.AddHttpClient<NeshanApiService>();
            
            services.AddHttpClient();

            services.AddJwtAuthentication(jwtSettings);
            services.AddZarinPalDriver();

            #region ( Background Services )

            services.AddHangfire(x => x.UseSqlServerStorage(configuration.GetConnectionString("DefaultConnection")));
            services.AddHangfireServer();
            services.AddTransient<UpdateSubscriptionClickService>();

            #endregion
        }


        public static IdentityBuilder AddIdentityService(this IServiceCollection services)
        {
            #region ( Identity )

            #region ( AddIdentity )

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;

                options.User.RequireUniqueEmail = false;
                options.User.AllowedUserNameCharacters = "0123456789";

                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedPhoneNumber = true;

                options.Lockout.AllowedForNewUsers = false;
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);

                options.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultPhoneProvider;
                options.Tokens.ChangePhoneNumberTokenProvider = TokenOptions.DefaultPhoneProvider;

            }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            #endregion

            #region ( Configure Cookie Options )

            services.ConfigureApplicationCookie(options =>
            {
                options.SlidingExpiration = true;
                options.Cookie.HttpOnly = true;
                options.Cookie.SameSite = SameSiteMode.None;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(1440);
                options.LogoutPath = $"/account/sign-out";
                options.LoginPath = $"/account/sign-in";
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

        public static void AddJwtAuthentication(this IServiceCollection services, JwtSettings jwtSettings)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                var secretKey = Encoding.UTF8.GetBytes(jwtSettings.SecretKey);
                var encryptionKey = Encoding.UTF8.GetBytes(jwtSettings.EncryptKey);

                var validationParameters = new TokenValidationParameters
                {
                    ClockSkew = TimeSpan.Zero, // default: 5 min
                    RequireSignedTokens = true,

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretKey),

                    RequireExpirationTime = true,
                    ValidateLifetime = true,

                    ValidateAudience = true, //default : false
                    ValidAudience = jwtSettings.Audience,

                    ValidateIssuer = true, //default : false
                    ValidIssuer = jwtSettings.Issuer,

                    TokenDecryptionKey = new SymmetricSecurityKey(encryptionKey)
                };

                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = validationParameters;
                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception != null)
                            //throw new AppException(ApiResultStatusCode.UnAuthorized, "Authentication failed.", HttpStatusCode.Unauthorized, context.Exception, null);
                            throw new Exception("Authentication failed.");

                        return Task.CompletedTask;
                    },
                    OnTokenValidated = async context =>
                    {
                        var customValidate = context.HttpContext.RequestServices
                            .GetRequiredService<JwtCustomValidation>();
                        await customValidate.Validate(context);
                    },
                    OnChallenge = context =>
                    {
                        //var logger = context.HttpContext.RequestServices.GetRequiredService<ILoggerFactory>().CreateLogger(nameof(JwtBearerEvents));
                        //logger.LogError("OnChallenge error", context.Error, context.ErrorDescription);

                        if (context.AuthenticateFailure != null)
                            throw new Exception("You are unauthorized to access this resource.");
                        //    throw new AppException(ApiResultStatusCode.UnAuthorized, "Authenticate failure.", HttpStatusCode.Unauthorized, context.AuthenticateFailure, null);
                        //throw new AppException(ApiResultStatusCode.UnAuthorized, "You are unauthorized to access this resource.", HttpStatusCode.Unauthorized);

                        return Task.CompletedTask;
                    }
                };
            });
        }

    }
}
