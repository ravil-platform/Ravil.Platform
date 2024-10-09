namespace Persistence.Entities.User.Configurations;

public class UserBlogActionConfigurations : IEntityTypeConfiguration<UserBlogAction>
{
    public void Configure(EntityTypeBuilder<UserBlogAction> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.BlogActionType).IsRequired();
        builder.Property(u => u.ActionScore).IsRequired();
        builder.Property(u => u.Rating).IsRequired(false);
        builder.Property(u => u.ActionDate).IsRequired();
    }
}