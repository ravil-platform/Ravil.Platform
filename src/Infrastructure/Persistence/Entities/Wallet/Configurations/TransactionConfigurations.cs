namespace Persistence.Entities.Wallet.Configurations;

public class TransactionConfigurations : IEntityTypeConfiguration<Domain.Entities.Wallets.Transaction>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Wallets.Transaction> builder)
    {
        builder.ToTable(nameof(Transaction), DatabaseSchemas.Wallet);

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Amount).IsRequired(false).IsUnicode();
        builder.Property(p => p.Number).IsRequired().IsUnicode();

        builder.Property(t => t.RefId).IsRequired(false).IsUnicode();
        builder.Property(t => t.AuthCode).IsRequired(false).IsUnicode();
        builder.Property(t => t.TrackingCode).IsRequired(false).HasMaxLength(MaxLength.RefCode);
        builder.Property(t => t.TransactionDate).IsRequired();

        //relations
        builder
            .HasMany(t => t.WalletTransactions)
            .WithOne(w => w.Transaction)
            .HasForeignKey(w => w.TransactionId)
            .IsRequired();
    }
}


