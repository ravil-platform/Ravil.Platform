namespace Persistence.Entities.Job.Configurations;

public class JobSelectionSliderConfigurations : IEntityTypeConfiguration<JobSelectionSlider>
{
    public void Configure(EntityTypeBuilder<JobSelectionSlider> builder)
    {
        builder.ToTable("JobSelectionSlider", DatabaseSchemas.Jobs);

        builder.HasKey(j => j.Id);
        builder.Property(j => j.JobSliderType).IsRequired();

        //relation
        builder
            .HasOne(j => j.JobBranch)
            .WithMany(j => j.JobSelectionSliders)
            .HasForeignKey(j => j.JobBranchId)
            .IsRequired();
    }
}