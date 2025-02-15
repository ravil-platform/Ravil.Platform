namespace Persistence.Entities.Category.Configurations;

internal class RelatedCategorySeoConfigurations : IEntityTypeConfiguration<RelatedCategorySeo>
{
    public void Configure(EntityTypeBuilder<RelatedCategorySeo> builder)
    {
        builder.ToTable(nameof(RelatedCategorySeo), DatabaseSchemas.Jobs);

        builder.HasKey(j => j.Id);
        builder.Property(j => j.Title);
        builder.Property(j => j.CurrentCityId);
        builder.Property(j => j.CurrentCityName);
        builder.Property(j => j.DisplayedCityName);
        builder.Property(j => j.Link);
        builder.Property(j => j.Sort);
    }
}