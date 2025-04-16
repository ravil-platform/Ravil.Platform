using Domain.Entities.Subscription;

namespace Persistence.Entities.Subscription.Configurations;

public class SubscriptionClickConfigurations : IEntityTypeConfiguration<SubscriptionClick>
{
    public void Configure(EntityTypeBuilder<SubscriptionClick> builder)
    {
        builder.ToTable("SubscriptionClick", DatabaseSchemas.Subscription);

        builder.HasKey(t => t.Id);
        builder.Property(t => t.ClickedTime).IsRequired();


        //relations
        builder.HasOne(f => f.Subscription)
            .WithMany(s => s.SubscriptionClicks)
            .HasForeignKey(s => s.SubscriptionId)
            .IsRequired();

        builder.HasOne(f => f.Click)
            .WithMany(s => s.SubscriptionClicks)
            .HasForeignKey(s => s.ClickId)
            .IsRequired();
    }
}