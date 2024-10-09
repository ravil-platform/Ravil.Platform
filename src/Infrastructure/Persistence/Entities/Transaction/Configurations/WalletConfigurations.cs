namespace Persistence.Entities.Transaction.Configurations;

public class WalletConfigurations : IEntityTypeConfiguration<Wallet>
{
    public void Configure(EntityTypeBuilder<Wallet> builder)
    {
        builder.ToTable("Wallets", "Transactions");

        builder.HasKey(w => w.Id);
        builder.Property(w => w.Inventory).IsRequired();

        //relations
        builder
            .HasMany(t => t.WalletTransaction)
            .WithOne(w => w.Wallet)
            .HasForeignKey(w => w.WalletId)
            .IsRequired();
    }
}