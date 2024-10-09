namespace Persistence.Entities.User.Configurations;

public class UserBannerClickConfigurations : IEntityTypeConfiguration<UserBannerClick>
{
    public void Configure(EntityTypeBuilder<UserBannerClick> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.CreateDate).IsRequired();

        //relations
        builder
            .HasOne(u => u.Banner)
            .WithMany(b => b.UserBannerClicks)
            .HasForeignKey(u => u.BannerId);

        builder
            .HasOne(u => u.ApplicationUser)
            .WithMany(b => b.UserBannerClicks)
            .HasForeignKey(u => u.UserId);
    }
}