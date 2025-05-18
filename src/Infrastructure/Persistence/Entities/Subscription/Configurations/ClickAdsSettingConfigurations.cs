using Domain.Entities.Subscription;

namespace Persistence.Entities.Subscription.Configurations
{
    public class ClickAdsSettingConfigurations : IEntityTypeConfiguration<ClickAdsSetting>
    {
        public void Configure(EntityTypeBuilder<ClickAdsSetting> builder)
        {
            builder.ToTable(nameof(ClickAdsSetting), DatabaseSchemas.Jobs);

            builder.HasKey(current => current.Id);

            builder.Property(current => current.MaxCostPerClick).IsRequired();
            builder.Property(current => current.Status).IsRequired().HasDefaultValue(false);
            builder.Property(current  => current.AdDisplayRange).HasMaxLength(MaxLength.AdDisplayRange);


            //relations
            builder
                .HasOne(u => u.User)
                .WithOne(s => s.ClickAdsSetting)
                .HasForeignKey<ClickAdsSetting>(w => w.UserId)
                .IsRequired();
        }
    }
}
