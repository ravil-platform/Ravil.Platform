namespace Persistence.Entities.Category.Configurations
{
    internal class CategoriesCityContentConfigurations : IEntityTypeConfiguration<CategoriesCityContent>
    {
        public void Configure(EntityTypeBuilder<CategoriesCityContent> builder)
        {
            builder.ToTable(nameof(CategoriesCityContent), DatabaseSchemas.Jobs);

            builder.HasKey(j => j.Id);
            builder.Property(j => j.CategoryId);
            builder.Property(j => j.CategoryName);
            builder.Property(j => j.CityId);
            builder.Property(j => j.CityName);
            builder.Property(j => j.Content);
        }
    }
}
