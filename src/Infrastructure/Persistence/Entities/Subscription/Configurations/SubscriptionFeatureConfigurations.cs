using Domain.Entities.Subscription;

namespace Persistence.Entities.Subscription.Configurations;

public class SubscriptionFeatureConfigurations : IEntityTypeConfiguration<SubscriptionFeature>
{
    public void Configure(EntityTypeBuilder<SubscriptionFeature> builder)
    {
        builder.ToTable("SubscriptionFeature", DatabaseSchemas.Subscription);

        builder.HasKey(t => t.Id);
    }
}