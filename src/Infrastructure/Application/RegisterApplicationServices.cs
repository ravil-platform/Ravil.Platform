using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Security.Claims;
using System.Text;
using Application.Contracts.Identity;
using Common.Utilities.Extensions;
using Persistence.Entities.User.Repositories.Interfaces;
using Application.Features.User.Commands.Create;

namespace Application
{
    public static class RegisterApplicationServices
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration, JwtSettings jwtSettings = null)
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

            services.AddValidatorsFromAssemblyContaining<CreateUserCommandValidator>();

            services.AddTransient(typeof(MediatR.IPipelineBehavior<,>), typeof(RNX.Mediator.ValidationBehavior<,>));

            services.AddTransient<IJwtService, JwtService>();

            services.AddJwtAuthentication(jwtSettings);
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
                        var signInManager = context.HttpContext.RequestServices.GetRequiredService<SignInManager<ApplicationUser>>();
                        var userRepository = context.HttpContext.RequestServices.GetRequiredService<IApplicationUserRepository>();

                        var claimsIdentity = context.Principal.Identity as ClaimsIdentity;
                        if (claimsIdentity.Claims?.Any() != true)
                            context.Fail("This token has no claims.");

                        var securityStamp = claimsIdentity.FindFirstValue(new ClaimsIdentityOptions().SecurityStampClaimType);
                        if (!securityStamp.HasValue())
                            context.Fail("This token has no security stamp");

                        //Find user and token from database and perform your custom validation
                        var userId = claimsIdentity.GetUserId<int>();
                        var user = await userRepository.GetByIdAsync(userId);


                        var validatedUser = await signInManager.ValidateSecurityStampAsync(context.Principal);
                        if (validatedUser == null)
                            context.Fail("Token security stamp is not valid.");

                        if (user.UserIsBlocked)
                            context.Fail("User is blocked.");
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
