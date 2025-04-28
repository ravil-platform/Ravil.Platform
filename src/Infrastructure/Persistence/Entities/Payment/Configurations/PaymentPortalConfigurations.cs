namespace Persistence.Entities.Payment.Configurations;

public class PaymentPortalConfigurations : IEntityTypeConfiguration<PaymentPortal>
{
    public void Configure(EntityTypeBuilder<PaymentPortal> builder)
    {
        builder.ToTable("PaymentPortal", DatabaseSchemas.Payment);
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Title).IsRequired();
        builder.Property(p => p.PictureName).IsRequired();
        builder.Property(p => p.IsActive).IsRequired();
    }
}