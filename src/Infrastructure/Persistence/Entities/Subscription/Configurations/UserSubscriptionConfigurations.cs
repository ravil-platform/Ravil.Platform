namespace Persistence.Entities.Subscription.Configurations;

public class UserSubscriptionConfigurations : IEntityTypeConfiguration<UserSubscription>
{
    public void Configure(EntityTypeBuilder<UserSubscription> builder)
    {
        builder.ToTable(nameof(UserSubscription), DatabaseSchemas.Subscription);

        builder.HasKey(t => t.Id);

        builder.Property(t => t.IsActive).IsRequired();
        builder.Property(t => t.IsFinally).IsRequired();
        builder.Property(t => t.StartDate).IsRequired();
        builder.Property(t => t.EndDate).IsRequired();
        builder.Property(t => t.RenewalDate).IsRequired(false);


        //relation
        builder.HasOne(s => s.User)
            .WithMany(s => s.UserSubscriptions)
            .HasForeignKey(s => s.UserId)
            .IsRequired();
    }
}