using Microsoft.EntityFrameworkCore.Design;

namespace Persistence.Context;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>

{

    public ApplicationDbContext CreateDbContext(string[] args)

    {

        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

        //// Read the connection string from appsettings.json or environment variables

        //IConfigurationRoot configuration = new ConfigurationBuilder()

        //    .SetBasePath(Directory.GetCurrentDirectory())

        //    .AddJsonFile("appsettings.json")

        //    .Build();

        //var connectionString = configuration.GetConnectionString("DefaultConnection");

        var connectionString =

            optionsBuilder.UseSqlServer("Server=.;Database=ravilDB;Encrypt=False;Trusted_Connection=True;");

        return new ApplicationDbContext(optionsBuilder.Options);

    }

}