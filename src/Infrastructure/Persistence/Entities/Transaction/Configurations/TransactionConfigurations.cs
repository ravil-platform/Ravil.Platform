namespace Persistence.Entities.Transaction.Configurations;

public class TransactionConfigurations : IEntityTypeConfiguration<Domain.Entities.Transaction.Transaction>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Transaction.Transaction> builder)
    {
        builder.ToTable("Transactions", "Transactions");

        builder.HasKey(t => t.Id);
        builder.Property(t => t.Title).IsRequired().HasMaxLength(MaxLength.Title);
        builder.Property(t => t.Description).IsRequired().HasMaxLength(MaxLength.Description);
        builder.Property(t => t.RefCode).IsRequired().HasMaxLength(MaxLength.RefCode);
        builder.Property(t => t.TransactionNumber).IsRequired();
        builder.Property(t => t.AuthCode).IsRequired();
        builder.Property(t => t.Amount).IsRequired();
        builder.Property(t => t.IsPay).IsRequired();
        builder.Property(t => t.TransactionDate).IsRequired();

        //relation
        builder
            .HasOne(t => t.Order)
            .WithMany(o => o.Transactions)
            .HasForeignKey(t => t.OrderId)
            .IsRequired(false);

        builder
            .HasMany(t => t.WalletTransaction)
            .WithOne(w => w.Transaction)
            .HasForeignKey(w => w.TransactionId)
            .IsRequired();
    }
}

