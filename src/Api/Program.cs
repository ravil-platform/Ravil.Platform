using Common.Utilities.ModelState;
using Constants.Security;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

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
services.AddApplicationServices(configuration, _siteSetting.JwtSettings);
services.AddPersistenceServices(configuration);

services.AddSwaggerDocumentation();

#region ( CORS Service )

builder.Services.AddCors(options =>
{
    options.AddPolicy(CORS.DefaultName, policyBuilder =>
    {
        string[] productionOrigins = ["https://api.ravil.ir", "https://admin.ravil.ir", "https://dl.newtan.academy", "https://ravil.vercel.app"];
        string[] developmentOrigins = ["https://localhost:7206", "https://localhost:7214", "http://127.0.0.1:3000", "http://localhost:3000"];
        string[] allAllowedOrigins = developmentOrigins.Concat(productionOrigins).ToArray();

        policyBuilder.SetIsOriginAllowedToAllowWildcardSubdomains()
            .WithOrigins(allAllowedOrigins)
            .AllowAnyMethod()
            .AllowAnyHeader();
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
app.Run();