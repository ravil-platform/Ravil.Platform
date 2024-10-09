namespace Persistence.Entities.Banner.Configurations
{
    public class BannerConfigurations : IEntityTypeConfiguration<Domain.Entities.Banner.Banner>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Banner.Banner> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.BannerType).IsRequired();
            builder.Property(b => b.BannerPictureType).IsRequired();
            builder.Property(b => b.Title).IsRequired().HasMaxLength(MaxLength.Title);
            builder.Property(b => b.Description).IsRequired().HasMaxLength(MaxLength.Description);
            builder.Property(b => b.ExpireDate).IsRequired();
            builder.Property(b => b.ExpireDay).IsRequired(false);
            builder.Property(b => b.LargePicture).IsRequired(false).HasMaxLength(MaxLength.Picture);
            builder.Property(b => b.SmallPicture).IsRequired(false).HasMaxLength(MaxLength.Picture);
            builder.Property(b => b.Sort).IsRequired(false);
            builder.Property(b => b.LinkPage).IsRequired(false);

            //relations
            builder
                .HasOne(b => b.JobBranch)
                .WithMany(j => j.Banners)
                .HasForeignKey(b => b.JobBranchId);

            //todo : user banner view & user banner click

        }
    }
}
