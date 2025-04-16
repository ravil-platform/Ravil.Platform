namespace Persistence.Entities.Subscription.Configurations
{
    public class SubscriptionConfigurations : IEntityTypeConfiguration<Domain.Entities.Subscription.Subscription>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Subscription.Subscription> builder)
        {
            builder.ToTable("Subscription", DatabaseSchemas.Subscription);

            builder.HasKey(t => t.Id);
            builder.Property(t => t.Icon).IsRequired().HasMaxLength(MaxLength.Picture);
            builder.Property(t => t.Title).IsRequired().HasMaxLength(MaxLength.Title);
            builder.Property(t => t.SubTitle).IsRequired().HasMaxLength(MaxLength.Title);
            builder.Property(t => t.DurationType).IsRequired();
            builder.Property(t => t.IsActive).IsRequired();

            //relations
            builder.HasMany(s => s.SubscriptionFeatures)
                .WithOne(s => s.Subscription)
                .HasForeignKey(s => s.SubscriptionId)
                .IsRequired();

            builder.HasMany(s => s.UserSubscriptions)
                .WithOne(s => s.Subscription)
                .HasForeignKey(s => s.SubscriptionId)
                .IsRequired();

            builder.HasData(
                new Domain.Entities.Subscription.Subscription
                {
                    Id = 1,
                    Icon = "empty.webp",
                    Title = "سه ماهه استاندارد",
                    SubTitle = "برای کسب‌وکارهای متوسط که رقیب‌های زیادی ندارند.",
                    Price = 50000000,
                    GiftCharge = 250000,
                    DurationTime = 90,
                    DurationType = SubscriptionDurationType.ThreeMonth,
                    IsActive = true,
                }, new Domain.Entities.Subscription.Subscription
                {
                    Id = 2,
                    Icon = "empty.webp",
                    Title = "شش ماهه استاندارد",
                    SubTitle = "برای کسب‌وکارهای متوسط که رقیب‌های زیادی ندارند.",
                    Price = 100000000,
                    GiftCharge = 500000,
                    DurationTime = 180,
                    DurationType = SubscriptionDurationType.SixMonth,
                    IsActive = true,
                }, new Domain.Entities.Subscription.Subscription
                {
                    Id = 3,
                    Icon = "empty.webp",
                    Title = "یک ساله استاندارد",
                    SubTitle = "برای کسب‌وکارهای متوسط که رقیب‌های زیادی ندارند.",
                    Price = 200000000,
                    GiftCharge = 1000000,
                    DurationTime = 365,
                    DurationType = SubscriptionDurationType.OneYear,
                    IsActive = true,
                }, new Domain.Entities.Subscription.Subscription
                {
                    Id = 4,
                    Icon = "empty.webp",
                    Title = "سه ماهه حرفه ای",
                    SubTitle = "برای کسب‌وکارهای که رقیب‌های زیادی دارند.",
                    Price = 500000000,
                    GiftCharge = 2500000,
                    DurationTime = 90,
                    DurationType = SubscriptionDurationType.ThreeMonth,
                    IsActive = true,
                }, new Domain.Entities.Subscription.Subscription
                {
                    Id = 5,
                    Icon = "empty.webp",
                    Title = "شش ماهه حرفه ای",
                    SubTitle = "برای کسب‌وکارهای که رقیب‌های زیادی دارند.",
                    Price = 1000000000,
                    GiftCharge = 5000000,
                    DurationTime = 180,
                    DurationType = SubscriptionDurationType.SixMonth,
                    IsActive = true,
                }, new Domain.Entities.Subscription.Subscription
                {
                    Id = 6,
                    Icon = "empty.webp",
                    Title = "یک ساله حرفه ای",
                    SubTitle = "برای کسب‌وکارهای که رقیب‌های زیادی دارند.",
                    Price = 2000000000,
                    GiftCharge = 10000000,
                    DurationTime = 365,
                    DurationType = SubscriptionDurationType.OneYear,
                    IsActive = true,
                });
        }
    }
}
