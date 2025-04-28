namespace Persistence.Entities.Job.Configurations;

public class JobInfoConfigurations : IEntityTypeConfiguration<JobInfo>
{
    public void Configure(EntityTypeBuilder<JobInfo> builder)
    {
        builder.ToTable("JobInfo", DatabaseSchemas.Jobs);

        builder.HasKey(j => j.Id);

        //relations
        builder.HasOne(w => w.Job)
            .WithOne(w => w.JobInfo)
            .HasForeignKey<JobInfo>(w => w.JobId);
    }
}