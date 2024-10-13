namespace Persistence.Entities.RedirectionUrl.Configurations;

public class RedirectionUrlConfigurations : IEntityTypeConfiguration<Domain.Entities.RedirectionUrl.RedirectionUrl>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.RedirectionUrl.RedirectionUrl> builder)
    {
        builder.ToTable("RedirectionUrl", DatabaseSchemas.RedirectionUrls);

        builder.HasKey(r => r.Id);
        builder.Property(r => r.Status).IsRequired();
        builder.Property(r => r.RedirectionType).IsRequired();
        builder.Property(r => r.LatestUrl).IsRequired();
        builder.Property(r => r.DestinationUrl).IsRequired();
    }
}

