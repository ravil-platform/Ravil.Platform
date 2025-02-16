namespace Persistence.Entities.Category.Configurations;

public class CategoryTagConfigurations : IEntityTypeConfiguration<CategoryTag>
{
    public void Configure(EntityTypeBuilder<CategoryTag> builder)
    {
        builder.ToTable(nameof(CategoryTag), DatabaseSchemas.Categories);
        builder.HasKey(c => c.Id);
        builder.Property(c => c.CategoryId);
        builder.Property(c => c.TagId);
    }
}