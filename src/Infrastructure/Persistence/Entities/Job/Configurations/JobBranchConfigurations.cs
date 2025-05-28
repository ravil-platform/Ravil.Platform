namespace Persistence.Entities.Job.Configurations
{
    public class JobBranchConfigurations : IEntityTypeConfiguration<JobBranch>
    {
        public void Configure(EntityTypeBuilder<JobBranch> builder)
        {
            builder.ToTable(nameof(JobBranch), DatabaseSchemas.Jobs);

            builder.HasKey(j => j.Id);

            builder.Property(j => j.Route).IsRequired(false).HasMaxLength(MaxLength.Slug);
            builder.Property(j => j.JobTimeWorkType).IsRequired();
            builder.Property(j => j.Title).IsRequired().HasMaxLength(MaxLength.Title);
            builder.Property(j => j.HeadingTitle).IsRequired(false).HasMaxLength(MaxLength.Title);
            builder.Property(j => j.Description).IsRequired(false).HasMaxLength(MaxLength.Description);
            builder.Property(j => j.BranchContent).IsRequired(false);
            builder.Property(j => j.BranchVideo).IsRequired(false).HasMaxLength(MaxLength.Video);
            builder.Property(j => j.LargePicture).IsRequired(false).HasMaxLength(MaxLength.Picture);
            builder.Property(j => j.SmallPicture).IsRequired(false).HasMaxLength(MaxLength.Picture);
            builder.Property(j => j.IsConfirmedByAdmin).IsRequired();
            builder.Property(j => j.ConfirmationDate).IsRequired(false);
            builder.Property(j => j.MapUrl).IsRequired(false);
            builder.Property(j => j.ViewCount).IsRequired();
            builder.Property(j => j.AverageRate).IsRequired();
            builder.Property(j => j.AdminName).IsRequired(false).HasMaxLength(MaxLength.Name);
            builder.Property(j => j.AdminId).IsRequired(false);
            builder.Property(j => j.IsOffer).IsRequired();
            builder.Property(j => j.IsAdminCreator).IsRequired();
            builder.Property(j => j.IsResizePicture).IsRequired();
            builder.Property(j => j.RejectedReason).IsRequired(false);
            builder.Property(j => j.Status).IsRequired(false);

            //relations
            builder
                .HasMany(j => j.Comments)
                .WithOne(c => c.JobBranch)
                .HasForeignKey(c => c.JobBranchId)
                .IsRequired(false);
        }
    }
}
