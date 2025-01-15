using Application.Profiles;
using Application.Services.SMS;
using Common.Options;
using Common.Utilities.Services.FTP;
using Common.Utilities.Services.FTP.Models;
using Logging.Adapters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Persistence.Context;
using System.Reflection;

#region ( Services )
var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.Configure<FTPConnectionOptions>(configuration.GetSection(nameof(FTPConnectionOptions)));
var siteSetting = configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>();
services.Configure<SiteSettings>(configuration.GetSection(nameof(SiteSettings)));

services.AddControllersWithViews();

#region ( Application Service In API )

services.AddSingleton<IFtpService, FtpService>();

services.AddHttpContextAccessor();
services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
services.AddAutoMapper(typeof(MappingProfile));
services.AddTransient(serviceType: typeof(Logging.Base.ILogger<>), implementationType: typeof(NLogAdapter<>));

var siteSettingConfiguration = configuration.GetSection(nameof(SiteSettings));
services.Configure<IOptions<SiteSettings>>(siteSettingConfiguration);

services.AddIdentityService();
services.AddTransient<ISmsSender, SmsSender>();
services.AddHttpClient();
#endregion

#region ( Pertistence Service in Api )
var assembly = typeof(ApplicationDbContext).GetTypeInfo().Assembly.GetName();

services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseLazyLoadingProxies(false);
    option.EnableSensitiveDataLogging();
    option.EnableDetailedErrors();
    option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
        acion => acion.MigrationsAssembly(assembly.Name));
});

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

#region ( Middlewares )
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/ErrorHandler/{0}");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
#endregion