using Domain.Entities.Subscription;

namespace Persistence.Entities.Subscription.Configurations;

public class ClickConfigurations : IEntityTypeConfiguration<Click>
{
    public void Configure(EntityTypeBuilder<Click> builder)
    {
        builder.ToTable("Click", DatabaseSchemas.Subscription);

        builder.HasKey(t => t.Id);
        builder.Property(t => t.Title).IsRequired().HasMaxLength(MaxLength.Title);
        builder.Property(t => t.CostPerClick).IsRequired();
        builder.Property(t => t.Type).IsRequired();
        
        builder.HasData(
            new Click
            {
                Id = 1,
                Title = "کلیک روی تبلیغات",
                CostPerClick = 30000,
                Type = ClickType.ClickOnAds
            },
            new Click
            {
                Id = 2,
                Title = "کلیک روی مسیریابی",
                CostPerClick = 15000,
                Type = ClickType.ClickOnMaps
            },
            new Click
            {
                Id = 3,
                Title = "کلیک روی تماس",
                CostPerClick = 20000,
                Type = ClickType.ClickOnCall
            }
        );

    }
}