namespace Persistence.Entities.Transaction.Configurations;

public class WalletTransactionConfigurations : IEntityTypeConfiguration<Domain.Entities.Transaction.Transaction>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Transaction.Transaction> builder)
    {
        builder.HasKey(w => w.Id);
    }
}