namespace Persistence.Entities.Order.Configurations
{
    public class OrderConfigurations : IEntityTypeConfiguration<Domain.Entities.Order.Order>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Order.Order> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Price).IsRequired();
            builder.Property(o => o.Discount).IsRequired();
            builder.Property(o => o.DiscountAmount).IsRequired();
            builder.Property(o => o.PaymentAmount).IsRequired();
            builder.Property(o => o.ExpireDay).IsRequired();
            builder.Property(o => o.ExpireDate).IsRequired();
            builder.Property(o => o.Status).IsRequired();
            builder.Property(o => o.IsActiveAccount).IsRequired();
            builder.Property(o => o.AdditionalInfo).IsRequired();
            builder.Property(o => o.AdminId).IsRequired(false);
            builder.Property(o => o.AdminName).IsRequired(false);
            builder.Property(o => o.CookieValue).IsRequired(false);
            builder.Property(o => o.JobId).IsRequired();
        }
    }
}
