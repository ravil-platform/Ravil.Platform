var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

var _siteSetting = configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>();

services.Configure<SiteSettings>(configuration.GetSection(nameof(SiteSettings)));

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();


services.AddApplicationServices(configuration, _siteSetting.JwtSettings);
services.AddPersistenceServices(configuration);

services.AddSwaggerDocumentation();

var app = builder.Build();

if (app.Environment.IsDevelopment())
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
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();