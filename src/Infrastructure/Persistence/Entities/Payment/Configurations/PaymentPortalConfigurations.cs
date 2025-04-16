namespace Persistence.Entities.Payment.Configurations;

public class PaymentPortalConfigurations : IEntityTypeConfiguration<Domain.Entities.Payment.PaymentPortal>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Payment.PaymentPortal> builder)
    {
        builder.ToTable("Payment", DatabaseSchemas.Payment);
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Title).IsRequired();
        builder.Property(p => p.PictureName).IsRequired();
        builder.Property(p => p.IsActive).IsRequired();
    }
}