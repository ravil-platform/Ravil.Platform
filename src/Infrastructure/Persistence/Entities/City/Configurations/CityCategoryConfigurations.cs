namespace Persistence.Entities.City.Configurations;

public class CityCategoryConfigurations : IEntityTypeConfiguration<CityCategory>
{
    public void Configure(EntityTypeBuilder<CityCategory> builder)
    {
        builder.HasKey(c => c.Id);
    }
}