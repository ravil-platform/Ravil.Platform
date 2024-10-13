namespace Persistence.Entities.User.Configurations;

public class UserAddressConfigurations : IEntityTypeConfiguration<UserAddress>
{
    public void Configure(EntityTypeBuilder<UserAddress> builder)
    {
        builder.ToTable("UserAddresse", DatabaseSchemas.Users);

        builder.HasKey(u => u.Id);
        builder.Property(u => u.ReceiverName).IsRequired().HasMaxLength(MaxLength.Name);
        builder.Property(u => u.PhoneNumber).IsRequired().HasMaxLength(MaxLength.Phone);
        builder.Property(u => u.PostalAddress).IsRequired();
        builder.Property(u => u.PostalCode).IsRequired().HasMaxLength(MaxLength.PostalCode);

        builder
            .HasOne(u => u.StateBase)
            .WithMany(s => s.UserAddresses)
            .HasForeignKey(u => u.StateBaseId)
            .IsRequired();

        builder
            .HasOne(u => u.CityBase)
            .WithMany(s => s.UserAddresses)
            .HasForeignKey(u => u.CityBaseId)
            .IsRequired();
    }
}