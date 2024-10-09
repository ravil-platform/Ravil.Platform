namespace Persistence.Entities.Job.Configurations;

public class JobLocationConfigurations : IEntityTypeConfiguration<JobLocation>
{
    public void Configure(EntityTypeBuilder<JobLocation> builder)
    {
        builder.HasKey(j => j.Id);
    }
}