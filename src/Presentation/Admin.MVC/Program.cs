using Common.Options;
using Logging.Adapters;
using System.Reflection;
using StackExchange.Redis;
using Persistence.Context;
using Application.Profiles;
using Application.Middlewares;
using NuGet.Packaging;

#region ( Services )

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;
var environment = builder.Environment;

services.Configure<FTPConnectionOptions>(configuration.GetSection(nameof(FTPConnectionOptions)));

var redisCacheOptions = configuration.GetSection(nameof(RedisCacheOptions)).Get<RedisCacheOptions>();
services.Configure<RedisCacheOptions>(configuration.GetSection(nameof(RedisCacheOptions)));

var siteSetting = configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>();
services.Configure<SiteSettings>(configuration.GetSection(nameof(SiteSettings)));

services.AddControllersWithViews();

#region ( Application Service In API )

#region ( Caching Services )

//services.AddMemoryCache();
//services.AddDistributedMemoryCache();
services.AddStackExchangeRedisCache(options =>
{
    if (redisCacheOptions != null)
    {
        var configurationRedisCache = ConfigurationOptions.Parse(redisCacheOptions.ConnectionString 
            ?? $"{redisCacheOptions.IpAddress}:{redisCacheOptions.Port}");
        
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

#region ( CORS Service )

builder.Services.AddCors(options =>
{
    options.AddPolicy(CORS.DefaultName, policyBuilder =>
    {
        string[] productionOrigins = ["https://api.ravil.ir", "https://admin.ravil.ir", "https://dl.newtan.academy", "https://ravil.liara.run"];
        string[] developmentOrigins = ["https://localhost:7206", "https://localhost:7214", "http://127.0.0.1:3000", "http://localhost:3000", "https://localhost:3000"];
        string[] allAllowedOrigins = developmentOrigins;

        if (builder.Environment.IsProduction())
        {
            productionOrigins.AddRange(developmentOrigins);
            allAllowedOrigins = productionOrigins;
        }
        else
        {
            productionOrigins.AddRange(developmentOrigins);
            allAllowedOrigins = productionOrigins;
        }

        policyBuilder.SetIsOriginAllowedToAllowWildcardSubdomains()
            .WithOrigins(allAllowedOrigins)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
            .Build();
    });
});
#endregion

#region ( LoggingServices )

if (builder.Environment.IsProduction())
{
    NLog.LogManager.Configuration.Variables["rootDir"] = AppDomain.CurrentDomain.BaseDirectory;
}
else if (builder.Environment.IsDevelopment())
{
    NLog.LogManager.Configuration.Variables["rootDir"] = @"C:\Temp\AdminRavilLogs\";
}
else
{
    NLog.LogManager.Configuration.Variables["rootDir"] = AppDomain.CurrentDomain.BaseDirectory;
}
services.AddTransient(serviceType: typeof(Logging.Base.ILogger<>), implementationType: typeof(NLogAdapter<>));

#endregion

#region ( DI )

services.AddSingleton<IFtpService, FtpService>();

services.AddHttpContextAccessor();
services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
services.AddAutoMapper(typeof(MappingProfile));

var siteSettingConfiguration = configuration.GetSection(nameof(SiteSettings));
services.Configure<IOptions<SiteSettings>>(siteSettingConfiguration);

services.AddIdentityService();
services.AddHttpClient<NeshanApiService>();
services.AddTransient<ISmsSender, SmsSender>();
services.AddHttpClient();

#endregion

#endregion

#region ( Pertistence Service in Api )

#region ( DbContext )

//services.AddApplicationDbContext(configuration);

var assembly = typeof(ApplicationDbContext).GetTypeInfo().Assembly.GetName();
services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseLazyLoadingProxies();
    option.EnableSensitiveDataLogging();
    option.EnableDetailedErrors();
    option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
        acion => acion.MigrationsAssembly(assembly.Name));
});

#endregion

#region ( UnitOfWork )

services.AddTransient<Persistence.Contracts.IUnitOfWork, UnitOfWork>(current =>
{
    string databaseConnectionString =
        configuration.GetSection(key: "ConnectionStrings").GetSection(key: "DefaultConnection").Value!;

    string databaseProviderString =
        configuration.GetSection(key: "DatabaseProvider").Value!;

    RNX.Persistence.Enums.Provider databaseProvider =
        (RNX.Persistence.Enums.Provider)
        System.Convert.ToInt32(databaseProviderString);

    RNX.Persistence.Options options =
        new RNX.Persistence.Options
        {
            Provider = databaseProvider,
            ConnectionString = databaseConnectionString,
        };

    return new UnitOfWork(options: options);
});

#endregion

#endregion

#endregion

#region ( Middlewares )

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseHsts();
}

// Configure the HTTP request pipeline
app.UseDeveloperExceptionPage();
app.UseCustomExceptionMvcHandler();

// Add these lines before UseRouting
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();
app.UseRouting();

app.UseCors(CORS.DefaultName);
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

#endregion