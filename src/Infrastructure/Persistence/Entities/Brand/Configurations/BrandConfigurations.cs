namespace Persistence.Entities.Brand.Configurations
{
    public class BrandConfigurations : IEntityTypeConfiguration<Domain.Entities.Brand.Brand>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Brand.Brand> builder)
        {
            builder.ToTable("Brand", DatabaseSchemas.Brands);

            builder.HasKey(b => b.Id);
            builder.Property(b => b.Title).IsRequired().HasMaxLength(MaxLength.Title);
            builder.Property(b => b.AlternateTitle).IsRequired(false).HasMaxLength(MaxLength.Title);
            builder.Property(b => b.Introduction).IsRequired(false);
            builder.Property(b => b.SearchLink).IsRequired(false);
            builder.Property(b => b.Picture).IsRequired(false).HasMaxLength(MaxLength.Picture);
            builder.Property(b => b.Status).IsRequired(true);
        }
    }
}
