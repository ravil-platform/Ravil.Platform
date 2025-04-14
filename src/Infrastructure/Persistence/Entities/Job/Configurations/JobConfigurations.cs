namespace Persistence.Entities.Job.Configurations;

public class JobConfigurations : IEntityTypeConfiguration<Domain.Entities.Job.Job>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Job.Job> builder)
    {
        builder.ToTable("Job", DatabaseSchemas.Jobs);

        builder.HasKey(j => j.Id);
        builder.Property(j => j.Route).IsRequired(false).HasMaxLength(MaxLength.Slug);
        builder.Property(j => j.Title).IsRequired().HasMaxLength(MaxLength.Title);
        builder.Property(j => j.SubTitle).IsRequired(false).HasMaxLength(MaxLength.Title);
        builder.Property(j => j.Summary).IsRequired(false).HasMaxLength(MaxLength.Summary);
        builder.Property(j => j.Content).IsRequired(false).HasMaxLength(MaxLength.Content);
        builder.Property(j => j.LargePicture).IsRequired(false).HasMaxLength(MaxLength.Picture);
        builder.Property(j => j.SmallPicture).IsRequired(false).HasMaxLength(MaxLength.Picture);
        builder.Property(j => j.Email).IsRequired(false).HasMaxLength(MaxLength.Email);
        builder.Property(j => j.WebSiteName).IsRequired(false).HasMaxLength(MaxLength.Name);
        builder.Property(j => j.PhoneNumberInfos).IsRequired(false);
        builder.Property(j => j.SocialMediaInfos).IsRequired(false);
        builder.Property(j => j.ShowPhoneTelInSite).IsRequired(false);
        builder.Property(j => j.ShowFirstPhoneMobileInSite).IsRequired(false);
        builder.Property(j => j.IsResizePicture).IsRequired();
        builder.Property(j => j.AdminName).IsRequired(false);
        builder.Property(j => j.AdminId).IsRequired(false);
        builder.Property(j => j.ViewCountTotal).IsRequired();
        builder.Property(j => j.AverageRate).IsRequired();
        builder.Property(j => j.IsGoogleData).IsRequired();
        builder.Property(j => j.RejectedReason).IsRequired(false);
        builder.Property(j => j.Status).IsRequired(false);

        //relations
        builder
            .HasOne(j => j.Brand)
            .WithMany(b => b.Jobs)
            .HasForeignKey(j => j.JobBrandId);

        builder
            .HasMany(j => j.JobBranches)
            .WithOne(j => j.Job)
            .HasForeignKey(j => j.JobId)
            .IsRequired();

        builder
            .HasMany(j => j.JobTags)
            .WithOne(j => j.Job)
            .HasForeignKey(j => j.JobId)
            .IsRequired();

        builder
            .HasMany(j => j.JobCategories)
            .WithOne(j => j.Job)
            .HasForeignKey(j => j.JobId)
            .IsRequired();
    }
}

