using Domain.Entities.Payment;

namespace Persistence.Entities.Payment.Configurations
{
    public class PromotionCodeConfigurations : IEntityTypeConfiguration<PromotionCode>
    {
        public void Configure(EntityTypeBuilder<PromotionCode> builder)
        {
            builder.ToTable("PromotionCode", DatabaseSchemas.Payment);

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Title).IsRequired().HasMaxLength(MaxLength.Title);
            builder.Property(p => p.Code).IsRequired().HasMaxLength(MaxLength.Code);
            builder.Property(p => p.CreateDate).IsRequired();
            builder.Property(p => p.ExpireDate).IsRequired();
            builder.Property(p => p.Amount).IsRequired();
            builder.Property(p => p.Type).IsRequired();
            builder.Property(p => p.CartMinimum).IsRequired(false);
            builder.Property(p => p.CartMaximum).IsRequired(false);
            builder.Property(p => p.UseCountLimit).IsRequired(false);
            builder.Property(p => p.IsUseLimit).IsRequired();
            builder.Property(p => p.IsActiveForDiscounts).IsRequired();
            builder.Property(p => p.Status).IsRequired();
        }
    }
}
