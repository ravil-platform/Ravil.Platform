using Application.Profiles;
using Application.Services.NehsanApi;
using Application.Services.SMS;
using Common.Options;
using Common.Utilities.Services.FTP;
using Common.Utilities.Services.FTP.Models;
using Logging.Adapters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Persistence.Context;
using System.Reflection;
using Application.Middlewares;
using Constants.Security;

#region ( Services )

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;
var environment = builder.Environment;

services.Configure<FTPConnectionOptions>(configuration.GetSection(nameof(FTPConnectionOptions)));
var siteSetting = configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>();
services.Configure<SiteSettings>(configuration.GetSection(nameof(SiteSettings)));

services.AddControllersWithViews();

#region ( Application Service In API )

#region ( CORS Service )

builder.Services.AddCors(options =>
{
    options.AddPolicy(CORS.DefaultName, policyBuilder =>
    {
        string[] productionOrigins = ["https://api.ravil.ir", "https://dl.newtan.academy", "https://ravil.liara.run"];
        string[] developmentOrigins = ["https://localhost:7206", "https://localhost:7214", "http://127.0.0.1:3000", "http://localhost:3000"];
        string[] allAllowedOrigins = developmentOrigins;

        if (builder.Environment.IsProduction())
        {
            allAllowedOrigins = productionOrigins.Append("http://localhost:3000").ToArray();
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
    NLog.LogManager.Configuration.Variables["rootDir"] = @"C:\Temp\RavilLogs\";
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
    option.UseLazyLoadingProxies(false);
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
    //app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseDeveloperExceptionPage();
app.UseCustomExceptionMvcHandler();
//app.UseStatusCodePagesWithReExecute("/ErrorHandler/{0}");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseCors(CORS.DefaultName);
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

#endregion