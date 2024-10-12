namespace Persistence.Entities.Job.Configurations;

public class JobServiceConfigurations : IEntityTypeConfiguration<JobService>
{
    public void Configure(EntityTypeBuilder<JobService> builder)
    {
        builder.ToTable("JobServices", "Jobs");

        builder.HasKey(j => j.Id);

        //relations 
        builder
            .HasOne(j => j.JobBranch)
            .WithMany(j => j.JobServices)
            .HasForeignKey(j => j.JobBranchId)
            .IsRequired();
    }
}