namespace Persistence.Entities.Job.Configurations;

public class JobCategoryAttrConfigurations : IEntityTypeConfiguration<JobCategoryAttr>
{
    public void Configure(EntityTypeBuilder<JobCategoryAttr> builder)
    {
        builder.ToTable("JobCategoriyAttrs", "Jobs");

        builder.HasKey(j => j.Id);
    }
}