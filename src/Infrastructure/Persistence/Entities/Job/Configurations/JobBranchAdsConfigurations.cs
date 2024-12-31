namespace Persistence.Entities.Job.Configurations;

public class JobBranchAdsConfigurations : IEntityTypeConfiguration<JobBranchAds>
{
    public void Configure(EntityTypeBuilder<JobBranchAds> builder)
    {
        builder.ToTable(nameof(JobBranchAds), DatabaseSchemas.Jobs);

        builder.HasKey(j => j.Id);
        builder.Property(j => j.CategoryId);
        builder.Property(j => j.CategoryName);
        builder.Property(j => j.JobBranchId);
        builder.Property(j => j.JobBranchName);
        builder.Property(j => j.Sort);
        builder.Property(j => j.Pinned);
    }
}