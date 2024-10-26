namespace Persistence.Entities.City.Configurations
{
    public class CityConfigurations : IEntityTypeConfiguration<Domain.Entities.City.City>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.City.City> builder)
        {
            builder.ToTable("City", DatabaseSchemas.Cities);

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Subtitle).IsRequired().HasMaxLength(MaxLength.Title);
            builder.Property(c => c.Route).IsRequired(false).HasMaxLength(MaxLength.Slug);
            builder.Property(c => c.Picture).IsRequired(false).HasMaxLength(MaxLength.Picture);
            builder.Property(c => c.Status).IsRequired();
            builder.Property(c => c.IsResizePicture).IsRequired();

            //relations
            builder
                .HasMany(c => c.CityCategories)
                .WithOne(c => c.City)
                .HasForeignKey(c => c.CityId)
                .IsRequired();
        }
    }
}