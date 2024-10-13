namespace Persistence.Entities.Job.Configurations;

public class JobTagConfigurations : IEntityTypeConfiguration<JobTag>
{
    public void Configure(EntityTypeBuilder<JobTag> builder)
    {
        builder.ToTable("JobTag", DatabaseSchemas.Jobs);

        builder.HasKey(j => j.Id);
    }
}