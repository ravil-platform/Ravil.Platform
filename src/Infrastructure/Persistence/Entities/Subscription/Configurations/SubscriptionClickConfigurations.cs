
namespace Persistence.Entities.Subscription.Configurations;

public class SubscriptionClickConfigurations : IEntityTypeConfiguration<SubscriptionClick>
{
    public void Configure(EntityTypeBuilder<SubscriptionClick> builder)
    {
        builder.ToTable(nameof(SubscriptionClick), DatabaseSchemas.Subscription);

        builder.HasKey(t => t.Id);

        builder.Property(t => t.CostPerClick).IsRequired();
        builder.Property(t => t.ClickedTime).IsRequired();
        builder.Property(t => t.Position).IsRequired(false);

        builder.Property(t => t.KeywordId).IsRequired(false);
        builder.Property(t => t.KeywordSlug).IsRequired();
        builder.Property(t => t.KeywordPageUrl).IsRequired();
        builder.Property(t => t.KeywordPageTitle).IsRequired();

        builder.Property(t => t.IsDeposit).IsRequired().HasDefaultValue(false);


        //relations
        builder.HasOne(f => f.Subscription)
            .WithMany(s => s.SubscriptionClicks)
            .HasForeignKey(s => s.SubscriptionId)
            .IsRequired();

        builder.HasOne(f => f.Click)
            .WithMany(s => s.SubscriptionClicks)
            .HasForeignKey(s => s.ClickId)
            .IsRequired();

        builder.HasOne(f => f.Job)
            .WithMany(s => s.JobSubscriptionClicks)
            .HasForeignKey(s => s.JobId)
            .IsRequired();
    }
}