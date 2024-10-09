namespace Persistence.Entities.Account.Configurations
{
    public class AccountLevelConfigurations : IEntityTypeConfiguration<AccountLevel>
    {
        public void Configure(EntityTypeBuilder<AccountLevel> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.LevelTitle).IsRequired().HasMaxLength(MaxLength.Title);
            builder.Property(a => a.LevelStyle).IsRequired(false).HasMaxLength(MaxLength.Title);
        }
    }
}
