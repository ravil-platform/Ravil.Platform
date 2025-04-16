using Domain.Entities.Wallets;

namespace Persistence.Entities.Wallet.Configurations;

public class WalletTransactionConfigurations : IEntityTypeConfiguration<WalletTransaction>
{
    public void Configure(EntityTypeBuilder<WalletTransaction> builder)
    {
        builder.ToTable("WalletTransaction", DatabaseSchemas.Wallet);

        builder.HasKey(w => w.Id);
    }
}