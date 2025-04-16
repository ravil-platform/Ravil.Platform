using Domain.Entities.Subscription;

namespace Persistence.Entities.Subscription.Configurations;

public class FeatureConfigurations : IEntityTypeConfiguration<Feature>
{
    public void Configure(EntityTypeBuilder<Feature> builder)
    {
        builder.ToTable("Feature", DatabaseSchemas.Subscription);

        builder.HasKey(t => t.Id);
        builder.Property(t => t.Title).IsRequired().HasMaxLength(MaxLength.Title);


        //relations
        builder.HasMany(f => f.SubscriptionFeatures)
            .WithOne(s => s.Feature)
            .HasForeignKey(s => s.FeatureId)
            .IsRequired();
    }
}