namespace Persistence.Entities.User.Configurations;

public class UserBookMarkConfigurations : IEntityTypeConfiguration<UserBookMark>
{
    public void Configure(EntityTypeBuilder<UserBookMark> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.UserBookMarkType).IsRequired();
        builder.Property(u => u.BlogId).IsRequired(false);
        builder.Property(u => u.JobBranchId).IsRequired(false);
        builder.Property(u => u.UserIp).IsRequired(false);
    }
}