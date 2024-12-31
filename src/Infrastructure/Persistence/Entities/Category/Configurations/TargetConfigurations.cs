namespace Persistence.Entities.Category.Configurations;

public class TargetConfigurations : IEntityTypeConfiguration<Target>
{
    public void Configure(EntityTypeBuilder<Target> builder)
    {
        builder.ToTable(nameof(Target), DatabaseSchemas.Jobs);

        builder.HasKey(j => j.Id);
        builder.Property(j => j.DestinationCategoryId);
        builder.Property(j => j.DestinationCategoryName);
        builder.Property(j => j.OriginCategoryName);
        builder.Property(j => j.OriginCategoryName);
    }
}