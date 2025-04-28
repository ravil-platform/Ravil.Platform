namespace Persistence.Entities.ShortLink.Configurations;

public class ShortLinkConfigurations : IEntityTypeConfiguration<Domain.Entities.ShortLink.ShortLink>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.ShortLink.ShortLink> builder)
    {
        builder.ToTable("ShortLink", DatabaseSchemas.Shared);

        builder.HasKey(s => s.Id);
        builder.Property(s => s.ShortKey).IsRequired().HasMaxLength(MaxLength.ShortLinkLength);
        builder.Property(s => s.Type).IsRequired();
        builder.Property(s => s.ItemId).IsRequired();
    }
}
