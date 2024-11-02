namespace Persistence
{
    public static class RegisterPersistenceServices
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = typeof(ApplicationDbContext).GetTypeInfo().Assembly.GetName();

            services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseLazyLoadingProxies(false);
                option.EnableSensitiveDataLogging();
                option.EnableDetailedErrors();
                option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    acion => acion.MigrationsAssembly(assembly.Name));
            });

            services.AddTransient<Contracts.IUnitOfWork, UnitOfWork>(current =>
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

        }
    }
}
