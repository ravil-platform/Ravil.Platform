namespace Persistence.Entities.Job.Configurations;

public class JobCategoryConfigurations : IEntityTypeConfiguration<JobCategory>
{
    public void Configure(EntityTypeBuilder<JobCategory> builder)
    {
        builder.ToTable("JobCategories", "Jobs");

        builder.HasKey(j => j.Id);
    }
}