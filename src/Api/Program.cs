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



var app = builder.Build();


//using (var scope = app.Services.CreateScope())
//{
//    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
//    // use context
//    dbContext.Database.EnsureCreated();
//}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCustomExceptionHandler();
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();