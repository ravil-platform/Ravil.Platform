namespace Persistence.Entities.Job.Configurations
{
    public class JobBranchConfigurations : IEntityTypeConfiguration<JobBranch>
    {
        public void Configure(EntityTypeBuilder<JobBranch> builder)
        {
            builder.ToTable("JobBranchs", "Jobs");

            builder.HasKey(j => j.Id);
            builder.Property(j => j.Route).IsRequired().HasMaxLength(MaxLength.Slug);
            builder.Property(j => j.JobTimeWorkType).IsRequired();
            builder.Property(j => j.Title).IsRequired().HasMaxLength(MaxLength.Title);
            builder.Property(j => j.HeadingTitle).IsRequired().HasMaxLength(MaxLength.Title);
            builder.Property(j => j.Description).IsRequired().HasMaxLength(MaxLength.Description);
            builder.Property(j => j.BranchContent).IsRequired().HasMaxLength(MaxLength.Content);
            builder.Property(j => j.BranchVideo).IsRequired(false).HasMaxLength(MaxLength.Video);
            builder.Property(j => j.LargePicture).IsRequired(false).HasMaxLength(MaxLength.Picture);
            builder.Property(j => j.SmallPicture).IsRequired(false).HasMaxLength(MaxLength.Picture);
            builder.Property(j => j.IsConfirmedByAdmin).IsRequired();
            builder.Property(j => j.ConfirmationDate).IsRequired();
            builder.Property(j => j.MapUrl).IsRequired(false);
            builder.Property(j => j.ViewCount).IsRequired(false);
            builder.Property(j => j.AverageRate).IsRequired(false);
            builder.Property(j => j.AdminName).IsRequired(false).HasMaxLength(MaxLength.Name);
            builder.Property(j => j.AdminId).IsRequired(false);
            builder.Property(j => j.IsOffer).IsRequired();
            builder.Property(j => j.IsAdminCreator).IsRequired();
            builder.Property(j => j.IsResizePicture).IsRequired();

            //relations
            builder
                .HasMany(j => j.Comments)
                .WithOne(c => c.JobBranch)
                .HasForeignKey(c => c.JobBranchId)
                .IsRequired(false);

            builder
                .HasMany(j => j.JobBranchAttributes)
                .WithOne(j => j.JobBranch)
                .HasForeignKey(c => c.JobBranchId)
                .IsRequired(false);


            builder
                .HasMany(j => j.Orders)
                .WithOne(j => j.JobBranch)
                .HasForeignKey(c => c.JobBranchId)
                .IsRequired(false);
        }
    }
}
