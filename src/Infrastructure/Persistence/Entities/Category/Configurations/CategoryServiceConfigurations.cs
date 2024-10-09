namespace Persistence.Entities.Category.Configurations;

public class CategoryServiceConfigurations : IEntityTypeConfiguration<CategoryService>
{
    public void Configure(EntityTypeBuilder<CategoryService> builder)
    {
        builder.HasKey(c => c.Id);
    }
}