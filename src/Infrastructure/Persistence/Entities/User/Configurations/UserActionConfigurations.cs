namespace Persistence.Entities.User.Configurations;

public class UserActionConfigurations : IEntityTypeConfiguration<UserAction>
{
    public void Configure(EntityTypeBuilder<UserAction> builder)
    {
        builder.ToTable("UserActions", "Users");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.JobBranchId).IsRequired(false);
        builder.Property(u => u.BlogId).IsRequired(false);
        builder.Property(u => u.ActionScore).IsRequired();
        builder.Property(u => u.Rating).IsRequired();
        builder.Property(u => u.ActionTypes).IsRequired();

        //relations
        builder
            .HasOne(u => u.ApplicationUser)
            .WithMany(a => a.UserActions)
            .HasForeignKey(u => u.UserId)
            .IsRequired();

        builder
            .HasOne(u => u.Action)
            .WithMany(a => a.UserActions)
            .HasForeignKey(u => u.ActionId)
            .IsRequired();
    }
}