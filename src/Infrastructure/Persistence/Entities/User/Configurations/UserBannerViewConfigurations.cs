namespace Persistence.Entities.User.Configurations;

public class UserBannerViewConfigurations : IEntityTypeConfiguration<UserBannerView>
{
    public void Configure(EntityTypeBuilder<UserBannerView> builder)
    {
        builder.ToTable("UserBannerView", DatabaseSchemas.Users);

        builder.HasKey(u => u.Id);

        //relations
        builder
            .HasOne(u => u.Banner)
            .WithMany(b => b.UserBannerViews)
            .HasForeignKey(u => u.BannerId);

        builder
            .HasOne(u => u.ApplicationUser)
            .WithMany(b => b.UserBannerViews)
            .HasForeignKey(u => u.UserId);
    }
}