namespace Persistence.Entities.Job.Configurations;

public class JobInfoConfigurations : IEntityTypeConfiguration<JobInfo>
{
    public void Configure(EntityTypeBuilder<JobInfo> builder)
    {
        builder.ToTable(nameof(JobInfo), DatabaseSchemas.Jobs);

        builder.HasKey(j => j.Id);
        builder.Property(j => j.CreateAt).IsRequired();
        builder.Property(j => j.IsActiveAds).IsRequired();

        //relations
        builder.HasOne(w => w.Job)
            .WithMany(w => w.JobInfos)
            .HasForeignKey(w => w.JobId);
    }
}