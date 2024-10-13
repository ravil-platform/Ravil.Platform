namespace Persistence.Entities.Account.Configurations
{
    public class AccountConfigurations : IEntityTypeConfiguration<Domain.Entities.Account.Account>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Account.Account> builder)
        {
            builder.ToTable("Account", DatabaseSchemas.Accounts);

            builder.HasKey(a => a.Id);
            builder.Property(p => p.Title).IsRequired().HasMaxLength(MaxLength.Title);
            builder.Property(p => p.Subtitle).IsRequired().HasMaxLength(MaxLength.Title);
            builder.Property(p => p.Content).IsRequired();
            builder.Property(p => p.Price).IsRequired();
            builder.Property(p => p.Discount).IsRequired();
            builder.Property(p => p.Status).IsRequired();
            builder.Property(p => p.ExpireDay).IsRequired();

            builder
                .HasOne(a => a.AccountLevel)
                .WithMany(a => a.Accounts)
                .HasForeignKey(a => a.AccountLevelId);

            builder
                .HasOne(a => a.AccountCategory)
                .WithMany(a => a.Accounts)
                .HasForeignKey(a => a.AccountCategoryId);

            builder
                .HasMany(a => a.AccountAttrs)
                .WithOne(a => a.Account)
                .HasForeignKey(a => a.AccountId);

            builder
                .HasMany(a => a.Orders)
                .WithOne(a => a.Account)
                .HasForeignKey(a => a.AccountId);
        }
    }
}
