namespace Persistence.Entities.User.Configurations;

public class UserBlogLikeConfigurations : IEntityTypeConfiguration<UserBlogLike>
{
    public void Configure(EntityTypeBuilder<UserBlogLike> builder)
    {
        builder.ToTable("UserBlogLike", DatabaseSchemas.Users);

        builder.HasKey(b => b.Id);
        builder.Property(b => b.LikeTimeDate);
    }
}