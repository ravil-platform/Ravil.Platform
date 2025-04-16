namespace Persistence.Entities.Wallet.Configurations;

public class WalletConfigurations : IEntityTypeConfiguration<Domain.Entities.Wallets.Wallet>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Wallets.Wallet> builder)
    {
        builder.ToTable("Wallet", DatabaseSchemas.Wallet);

        builder.HasKey(w => w.Id);
        builder.Property(w => w.Inventory).IsRequired();

        //relations
        builder
            .HasMany(t => t.WalletTransactions)
            .WithOne(w => w.Wallet)
            .HasForeignKey(w => w.WalletId)
            .IsRequired();


        builder.HasOne(w=> w.ApplicationUser)
            .WithOne(w=> w.Wallet)
            .HasForeignKey<Domain.Entities.Wallets.Wallet>(w => w.ApplicationUserId);
    }
}