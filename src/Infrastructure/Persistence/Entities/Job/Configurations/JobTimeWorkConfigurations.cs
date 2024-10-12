namespace Persistence.Entities.Job.Configurations;

public class JobTimeWorkConfigurations : IEntityTypeConfiguration<JobTimeWork>
{
    public void Configure(EntityTypeBuilder<JobTimeWork> builder)
    {
        builder.ToTable("JobTimeWorks", "Jobs");

        builder.HasKey(j => j.Id);
        builder.Property(j => j.StartTime).IsRequired().HasMaxLength(MaxLength.Title);
        builder.Property(j => j.EndTime).IsRequired().HasMaxLength(MaxLength.Title);

        //relations 
        builder
            .HasOne(j => j.JobBranch)
            .WithMany(j => j.JobTimeWorks)
            .HasForeignKey(j => j.JobBranchId)
            .IsRequired();
    }
}