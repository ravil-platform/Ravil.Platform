namespace Persistence.Entities.Job.Configurations;

public class JobCategoryAttrConfigurations : IEntityTypeConfiguration<JobCategoryAttr>
{
    public void Configure(EntityTypeBuilder<JobCategoryAttr> builder)
    {
        builder.HasKey(j => j.Id);
    }
}