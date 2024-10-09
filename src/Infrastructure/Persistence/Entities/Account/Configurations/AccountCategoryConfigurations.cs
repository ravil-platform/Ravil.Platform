namespace Persistence.Entities.Account.Configurations
{
    public class AccountCategoryConfigurations : IEntityTypeConfiguration<AccountCategory>
    {
        public void Configure(EntityTypeBuilder<AccountCategory> builder)
        {
            builder.ToTable("AccountCategories", "Accounts");

            builder.HasKey(a => a.Id);
            builder.Property(a => a.Title).IsRequired().HasMaxLength(MaxLength.Title);
            builder.Property(a => a.Status).IsRequired();
            builder.Property(a => a.Sort).IsRequired();
        }
    }
}
