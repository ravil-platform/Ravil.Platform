namespace Persistence.Entities.User.Configurations;

public class UserLikedGalleryConfigurations : IEntityTypeConfiguration<UserLikedGallery>
{
    public void Configure(EntityTypeBuilder<UserLikedGallery> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.UserLikedType).IsRequired();
        builder.Property(u => u.BlogId).IsRequired(false);
        builder.Property(u => u.JobBranchId).IsRequired(false);
        builder.Property(u => u.UserIp).IsRequired(false);

        //relations

    }
}