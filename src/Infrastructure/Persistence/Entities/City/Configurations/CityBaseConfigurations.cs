namespace Persistence.Entities.City.Configurations;

public class CityBaseConfigurations : IEntityTypeConfiguration<CityBase>
{
    public void Configure(EntityTypeBuilder<CityBase> builder)
    {
        builder.ToTable("CityBase", DatabaseSchemas.Cities);

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name).IsRequired().HasMaxLength(MaxLength.Name);
        builder.Property(c => c.CountyId).IsRequired();
        builder.Property(c => c.StateBaseId).IsRequired(false);


        //relations
        builder
            .HasOne(c => c.City)
            .WithOne(c => c.CityBase)
            .HasForeignKey<Domain.Entities.City.City>(c => c.CityBaseId);

        //builder
        //    .HasOne(c => c.StateBase)
        //    .WithOne(s => s.CityBase)
        //    .HasForeignKey<CityBase>(c => c.StateId)
        //    .IsRequired(false);

    }
}