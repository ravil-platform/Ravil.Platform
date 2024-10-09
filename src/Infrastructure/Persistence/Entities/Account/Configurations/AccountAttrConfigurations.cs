namespace Persistence.Entities.Account.Configurations
{
    public class AccountAttrConfigurations : IEntityTypeConfiguration<AccountAttr>
    {
        public void Configure(EntityTypeBuilder<AccountAttr> builder)
        {
            builder.HasKey(a => a.Id);
            builder
                .HasOne(a => a.AttrAccount)
                .WithMany(a => a.AttrAccounts)
                .HasForeignKey(a => a.AttrId);

            builder
                .HasOne(a => a.AttrAccountValue)
                .WithMany(a => a.AccountAttrs)
                .HasForeignKey(a => a.ValueId);
        }
    }
}
