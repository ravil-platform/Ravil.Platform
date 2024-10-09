namespace Persistence.Entities.City.Configurations;

public class CityBaseConfigurations : IEntityTypeConfiguration<CityBase>
{
    public void Configure(EntityTypeBuilder<CityBase> builder)
    {
        builder.ToTable("CityBases", "Cities");

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name).IsRequired().HasMaxLength(MaxLength.Name);
        builder.Property(c => c.CountyId).IsRequired(false);


        //relations
        builder
            .HasOne(c => c.City)
            .WithOne(c => c.CityBase)
            .HasForeignKey<Domain.Entities.City.City>(c => c.CityBaseId);
    }
}