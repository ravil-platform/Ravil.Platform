using Application.BackgroundServices;
using Common.Utilities.ModelState;
using Common.Utilities.Services.FTP;
using Common.Utilities.Services.FTP.Models;
using Constants.Security;
using Hangfire;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;
var environment = builder.Environment;

services.Configure<FTPConnectionOptions>(configuration.GetSection(nameof(FTPConnectionOptions)));

var _redisCacheOptions = configuration.GetSection(nameof(RedisCacheOptions)).Get<RedisCacheOptions>();
services.Configure<RedisCacheOptions>(configuration.GetSection(nameof(RedisCacheOptions)));

var _siteSetting = configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>();
services.Configure<SiteSettings>(configuration.GetSection(nameof(SiteSettings)));

services.AddControllers().ConfigureApiBehaviorOptions(option =>
{
    option.InvalidModelStateResponseFactory = (context =>
    {
        var result = new Result();

        result.WithError(ModelState.GetModelStateErrors(context.ModelState));

        return new BadRequestObjectResult(result);
    });
});
services.AddEndpointsApiExplorer();
services.AddApplicationServices(configuration, environment, _siteSetting?.JwtSettings, _redisCacheOptions);
services.AddPersistenceServices(configuration);
services.AddSingleton<IFtpService, FtpService>();

services.AddSwaggerDocumentation();

#region ( CORS Service )

builder.Services.AddCors(options =>
{
    options.AddPolicy(CORS.DefaultName, policyBuilder =>
    {
        string[] productionOrigins = ["https://ravil.ir", "https://api.ravil.ir", "https://admin.ravil.ir", "https://dl.newtan.academy", "https://ravil.liara.run", "https://ravil.vercel.app", "https://ravildashboardcom.vercel.app/"];
        string[] developmentOrigins = ["https://localhost:7206", "https://localhost:7214", "http://127.0.0.1:3000", "http://localhost:3000", "https://localhost:3000"];
        string[] allAllowedOrigins = productionOrigins.Concat(developmentOrigins).ToArray(); ;

        policyBuilder.SetIsOriginAllowedToAllowWildcardSubdomains()
            .WithOrigins(allAllowedOrigins)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
            .Build();
    });
});
#endregion




var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        var descriptions = app.DescribeApiVersions();

        // Build a swagger endpoint for each discovered API version
        foreach (var description in descriptions)
        {
            var url = $"/swagger/{description.GroupName}/swagger.json";
            var name = description.GroupName.ToUpperInvariant();
            options.SwaggerEndpoint(url, name);
        }
    });
}

app.UseCustomExceptionHandler();
app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();

app.UseCors(CORS.DefaultName);
app.UseAuthorization();

app.MapControllers();

app.UseHangfireDashboard();
// زمان‌بندی اجرای Job (هر روز ساعت 12 شب)
RecurringJob.AddOrUpdate<UpdateSubscriptionClickService>(
    service => service.UpdateSubscriptionClicks(),
    //"* * * * *", // Cron expression (هر روز ساعت 12 شب)
    "0 0 * * *", // Cron expression (هر روز ساعت 12 شب)
    TimeZoneInfo.Local);

RecurringJob.AddOrUpdate<ExportExcelToApiBackgroundService>(
    service => service.CreateInteractionFile(),
    "0 0 * * 0", // این کرون هر یک‌شنبه ساعت 12 شب (00:00) اجرا می‌شود
    TimeZoneInfo.Local);

app.Run();