namespace Persistence.Entities.Job.Configurations;

public class JobBranchTagConfigurations : IEntityTypeConfiguration<JobBranchTag>
{
    public void Configure(EntityTypeBuilder<JobBranchTag> builder)
    {
        builder.ToTable("JobBranchTags", "Jobs");

        builder.HasKey(j => j.Id);

        //relations
        builder
            .HasOne(j => j.JobBranch)
            .WithMany(j => j.JobBranchTags)
            .HasForeignKey(j => j.JobBranchId)
            .IsRequired();
    }
}