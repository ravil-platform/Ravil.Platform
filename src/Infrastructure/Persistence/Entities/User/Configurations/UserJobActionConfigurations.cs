namespace Persistence.Entities.User.Configurations;

public class UserJobActionConfigurations : IEntityTypeConfiguration<UserJobAction>
{
    public void Configure(EntityTypeBuilder<UserJobAction> builder)
    {
        builder.ToTable("UserJobActions", "Users");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.JobActionType).IsRequired();
        builder.Property(u => u.ActionScore).IsRequired();
        builder.Property(u => u.Rating).IsRequired();
        builder.Property(u => u.ActionDate).IsRequired();

        //relation
        builder
            .HasOne(u => u.JobBranch)
            .WithMany(u => u.JobUserActions)
            .HasForeignKey(u => u.JobBranchId)
            .IsRequired();
    }
}