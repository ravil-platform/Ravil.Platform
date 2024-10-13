namespace Persistence.Entities.Location.Configurations
{
    public class LocationConfigurations : IEntityTypeConfiguration<Domain.Entities.Location.Location>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Location.Location> builder)
        {
            builder.ToTable("Location", DatabaseSchemas.Locations);

            builder.HasKey(l => l.Id);
            builder.Property(l => l.Route).IsRequired(false).HasMaxLength(MaxLength.Slug);
            builder.Property(l => l.Lat).IsRequired();
            builder.Property(l => l.Long).IsRequired();
            builder.Property(l => l.PlaceType).IsRequired();
        }
    }
}
