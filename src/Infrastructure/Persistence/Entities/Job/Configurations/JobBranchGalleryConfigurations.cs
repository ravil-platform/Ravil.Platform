namespace Persistence.Entities.Job.Configurations;

public class JobBranchGalleryConfigurations : IEntityTypeConfiguration<JobBranchGallery>
{
    public void Configure(EntityTypeBuilder<JobBranchGallery> builder)
    {
        builder.HasKey(j => j.Id);
        builder.Property(j => j.ImageName).IsRequired(false).HasMaxLength(MaxLength.Picture);
        builder.Property(j => j.Sort).IsRequired().HasMaxLength(MaxLength.Picture);

        //relations
        builder
            .HasOne(j => j.JobBranch)
            .WithMany(j => j.JobBranchGalleries)
            .HasForeignKey(j => j.JobBranchId)
            .IsRequired();
    }
}