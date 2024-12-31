namespace Persistence.Entities.Job.Configurations;

public class JobBranchRelatedJobConfigurations : IEntityTypeConfiguration<JobBranchRelatedJob>
{
    public void Configure(EntityTypeBuilder<JobBranchRelatedJob> builder)
    {
        builder.ToTable(nameof(JobBranchRelatedJob), DatabaseSchemas.Jobs);

        builder.HasKey(j => j.Id);
        builder.Property(j => j.CurrentCityId);
        builder.Property(j => j.DisplayedCityId);
        builder.Property(j => j.CurrentCityName);
        builder.Property(j => j.DisplayedCityName);
        builder.Property(j => j.Sort);
    }
}