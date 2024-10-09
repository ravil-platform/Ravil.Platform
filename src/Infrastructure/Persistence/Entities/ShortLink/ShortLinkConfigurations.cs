namespace Persistence.Entities.ShortLink;

public class ShortLinkConfigurations : IEntityTypeConfiguration<Domain.Entities.ShortLink.ShortLink>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.ShortLink.ShortLink> builder)
    {
        builder.ToTable("ShortLinks", "ShortLinks");

        builder.HasKey(s => s.Id);
        builder.Property(s => s.ShortKey).IsRequired().HasMaxLength(MaxLength.ShortLinkLength);
        builder.Property(s => s.Type).IsRequired();
        builder.Property(s => s.ItemId).IsRequired(false);
    }
}
