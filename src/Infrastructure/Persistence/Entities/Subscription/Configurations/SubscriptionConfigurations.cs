namespace Persistence.Entities.Subscription.Configurations
{
    public class SubscriptionConfigurations : IEntityTypeConfiguration<Domain.Entities.Subscription.Subscription>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Subscription.Subscription> builder)
        {
            builder.ToTable(nameof(Subscription), DatabaseSchemas.Subscription);

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Icon).IsRequired().HasMaxLength(MaxLength.Icon);
            builder.Property(t => t.Title).IsRequired().HasMaxLength(MaxLength.Title);
            builder.Property(t => t.SubTitle).IsRequired().HasMaxLength(MaxLength.Title);
            builder.Property(t => t.DurationType).IsRequired();
            builder.Property(t => t.IsActive).IsRequired();
            builder.Property(t => t.Type).IsRequired();

            builder.Property(t => t.Discount).IsRequired(false);
            builder.Property(t => t.DiscountAmount).IsRequired(false);


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
                    Price = 2_900_000,
                    GiftCharge = 150_000,
                    DurationTime = 90,
                    DurationType = SubscriptionDurationType.ThreeMonth,
                    Type = SubscriptionType.Standard,
                    IsActive = true,
                },
                new Domain.Entities.Subscription.Subscription
                {
                    Id = 2,
                    Icon = "empty.webp",
                    Title = "شش ماهه استاندارد",
                    SubTitle = "برای کسب‌وکارهای متوسط که رقیب‌های زیادی ندارند.",
                    Price = 4_150_000,
                    GiftCharge = 250_000,
                    Discount = 20,
                    DiscountAmount = 830_000,
                    DurationTime = 180,
                    DurationType = SubscriptionDurationType.SixMonth,
                    Type = SubscriptionType.Standard,
                    IsActive = true,
                },
                new Domain.Entities.Subscription.Subscription
                {
                    Id = 3,
                    Icon = "empty.webp",
                    Title = "یک ساله استاندارد",
                    SubTitle = "برای کسب‌وکارهای متوسط که رقیب‌های زیادی ندارند.",
                    Price = 8_600_000,
                    GiftCharge = 400_000,
                    Discount = 34,
                    DiscountAmount = 2_924_000,
                    DurationTime = 365,
                    DurationType = SubscriptionDurationType.OneYear,
                    Type = SubscriptionType.Standard,
                    IsActive = true,
                },
                new Domain.Entities.Subscription.Subscription
                {
                    Id = 4,
                    Icon = "empty.webp",
                    Title = "سه ماهه حرفه ای",
                    SubTitle = "برای کسب‌وکارهای که رقیب‌های زیادی دارند.",
                    Price = 4_500_000,
                    GiftCharge = 250_000,
                    DurationTime = 90,
                    DurationType = SubscriptionDurationType.ThreeMonth,
                    Type = SubscriptionType.Premium,
                    IsActive = true,
                },
                new Domain.Entities.Subscription.Subscription
                {
                    Id = 5,
                    Icon = "empty.webp",
                    Title = "شش ماهه حرفه ای",
                    SubTitle = "برای کسب‌وکارهای که رقیب‌های زیادی دارند.",
                    Price = 7_500_000,
                    GiftCharge = 400_000,
                    Discount = 20,
                    DiscountAmount = 1_500_000,
                    DurationTime = 180,
                    DurationType = SubscriptionDurationType.SixMonth,
                    Type = SubscriptionType.Premium,
                    IsActive = true,
                },
                new Domain.Entities.Subscription.Subscription
                {
                    Id = 6,
                    Icon = "empty.webp",
                    Title = "یک ساله حرفه ای",
                    SubTitle = "برای کسب‌وکارهای که رقیب‌های زیادی دارند.",
                    Price = 15_600_000,
                    GiftCharge = 900_000,
                    Discount = 34,
                    DiscountAmount = 5_304_000,
                    DurationTime = 365,
                    DurationType = SubscriptionDurationType.OneYear,
                    Type = SubscriptionType.Premium,
                    IsActive = true,
                });
        }
    }
}
