namespace Persistence.Entities.Address.Configurations
{
    public class AddressConfigurations : IEntityTypeConfiguration<Domain.Entities.Address.Address>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Address.Address> builder)
        {
            builder.ToTable("Addresses", "Addresses");

            builder.HasKey(a => a.Id);
            builder.Property(a => a.PostalAddress).IsRequired().HasMaxLength(MaxLength.Address);
            builder.Property(a => a.PostalCode).IsRequired().HasMaxLength(MaxLength.PostalCode);
            builder.Property(a => a.OtherAddress).IsRequired();
            builder.Property(a => a.Neighbourhood).IsRequired(false);
            builder.Property(a => a.CreateDate).IsRequired();
            builder.Property(a => a.UpdateDate).IsRequired(false);

            //relations
            builder
                .HasOne(a => a.State)
                .WithMany(s => s.Addresses)
                .HasForeignKey(a => a.StateId)
                .IsRequired();

            builder
                .HasOne(a => a.City)
                .WithMany(s => s.Addresses)
                .HasForeignKey(a => a.CityId)
                .IsRequired();

            builder
                .HasOne(a => a.JobBranch)
                .WithOne(s => s.Address)
                .HasForeignKey<Domain.Entities.Address.Address>(a => a.JobBranchId)
                .IsRequired();

            builder
                .HasOne(a => a.Location)
                .WithOne(s => s.Address)
                .HasForeignKey<Domain.Entities.Address.Address>(a => a.LocationId)
                .IsRequired();
        }
    }
}
