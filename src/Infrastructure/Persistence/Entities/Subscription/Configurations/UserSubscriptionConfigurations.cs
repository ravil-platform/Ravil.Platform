using Domain.Entities.Subscription;

namespace Persistence.Entities.Subscription.Configurations;

public class UserSubscriptionConfigurations : IEntityTypeConfiguration<UserSubscription>
{
    public void Configure(EntityTypeBuilder<UserSubscription> builder)
    {
        builder.ToTable("UserSubscription", DatabaseSchemas.Subscription);

        builder.HasKey(t => t.Id);
        builder.Property(t => t.StartDate).IsRequired();
        builder.Property(t => t.EndDate).IsRequired();


        //relation
        builder.HasOne(s => s.User)
            .WithMany(s => s.UserSubscriptions)
            .HasForeignKey(s => s.UserId)
            .IsRequired();

    }
}