namespace Persistence.Entities.PaymentPortal.Configurations
{
    public class PaymentPortalConfigurations : IEntityTypeConfiguration<Domain.Entities.PaymentPortal.PaymentPortal>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.PaymentPortal.PaymentPortal> builder)
        {
            builder.ToTable("PaymentPortals", "PaymentPortals");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Title).IsRequired().HasMaxLength(MaxLength.Title);
            builder.Property(p => p.Status).IsRequired();
            builder.Property(p => p.Picture).IsRequired().HasMaxLength(MaxLength.Picture);
        }
    }
}
