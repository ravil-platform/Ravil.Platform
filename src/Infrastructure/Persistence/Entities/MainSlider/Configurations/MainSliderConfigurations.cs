namespace Persistence.Entities.MainSlider.Configurations
{
    public class MainSliderConfigurations : IEntityTypeConfiguration<Domain.Entities.MainSlider.MainSlider>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.MainSlider.MainSlider> builder)
        {
            builder.ToTable("MainSlider", DatabaseSchemas.MainSliders);

            builder.HasKey(b => b.Id);
            builder.Property(b => b.Title).IsRequired().HasMaxLength(MaxLength.Title);
            builder.Property(b => b.ExpireDay).IsRequired(false);
            builder.Property(b => b.LargePicture).IsRequired(false).HasMaxLength(MaxLength.Picture);
            builder.Property(b => b.SmallPicture).IsRequired(false).HasMaxLength(MaxLength.Picture);
            builder.Property(b => b.LinkPage).IsRequired(false).HasMaxLength(MaxLength.Link);
            builder.Property(b => b.Sort).IsRequired();

            //relations
            builder
                .HasOne(m => m.JobBranch)
                .WithMany(j => j.MainSliders)
                .HasForeignKey(m => m.JobBranchId)
                .IsRequired();

            builder
                .HasOne(m => m.City)
                .WithMany(j => j.MainSliders)
                .HasForeignKey(m => m.CityId)
                .IsRequired();
        }
    }
}
