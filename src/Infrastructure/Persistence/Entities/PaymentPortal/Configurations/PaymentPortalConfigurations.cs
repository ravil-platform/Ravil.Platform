namespace Persistence.Entities.PaymentPortal.Configurations
{
    public class PaymentPortalConfigurations : IEntityTypeConfiguration<Domain.Entities.Payment.PaymentPortal>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Payment.PaymentPortal> builder)
        {
            builder.ToTable("PaymentPortal", DatabaseSchemas.PaymentPortals);

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Title).IsRequired().HasMaxLength(MaxLength.Title);
        }
    }
}
