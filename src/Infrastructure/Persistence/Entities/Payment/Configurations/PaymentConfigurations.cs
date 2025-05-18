namespace Persistence.Entities.Payment.Configurations;

public class PaymentConfigurations : IEntityTypeConfiguration<Domain.Entities.Payment.Payment>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Payment.Payment> builder)
    {
        builder.ToTable(nameof(Payment), DatabaseSchemas.Payment);

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Amount).IsRequired();
        builder.Property(p => p.Number).IsRequired().IsUnicode();
        builder.Property(p => p.PaymentDate).IsRequired();
        builder.Property(p => p.RenewalDate).IsRequired(false);


        //relation 
        builder.HasOne(p => p.UserSubscription)
            .WithOne(p => p.Payment)
            .HasForeignKey<Domain.Entities.Payment.Payment>(p => p.UserSubscriptionId);

        builder.HasOne(p => p.PromotionCode)
            .WithMany(p => p.Payments)
            .HasForeignKey(p => p.PromotionCodeId);

        builder.HasMany(p => p.Transactions)
            .WithOne(p => p.Payment)
            .HasForeignKey(p => p.PaymentId)
            .IsRequired(false);
    }
}