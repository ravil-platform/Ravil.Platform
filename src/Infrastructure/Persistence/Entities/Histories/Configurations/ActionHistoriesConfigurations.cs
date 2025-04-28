namespace Persistence.Entities.Histories.Configurations
{
    public class ActionHistoriesConfigurations : IEntityTypeConfiguration<ActionHistories>
    {
        public void Configure(EntityTypeBuilder<ActionHistories> builder)
        {
            builder.ToTable("ActionHistories", DatabaseSchemas.Shared);

            builder.HasKey(a => a.Id);
            builder.Property(p => p.FullName).IsRequired(false).HasMaxLength(MaxLength.FullName);
            builder.Property(p => p.CategoryName).IsRequired().HasMaxLength(MaxLength.Name);
            builder.Property(p => p.AddressIp).IsRequired().HasMaxLength(MaxLength.Ip);
            builder.Property(p => p.Location).IsRequired().HasMaxLength(MaxLength.Address);
            builder.Property(p => p.ActionType).IsRequired();
            builder.Property(p => p.Time).IsRequired();
        }
    }
}
