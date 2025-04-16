namespace Persistence.Entities.Job.Configurations;

public class KeywordConfigurations : IEntityTypeConfiguration<Keyword>
{
    public void Configure(EntityTypeBuilder<Keyword> builder)
    {
        builder.ToTable("Keyword", DatabaseSchemas.Jobs);

        builder.HasKey(j => j.Id);
        builder.Property(j => j.Title).IsRequired().HasMaxLength(MaxLength.Title);
        builder.Property(j => j.Slug).IsRequired().HasMaxLength(MaxLength.Slug);
        builder.Property(j => j.IsActive).IsRequired();

        //relation
        builder.HasOne(k => k.Category)
            .WithMany(c => c.Keywords)
            .HasForeignKey(c => c.CategoryId)
            .IsRequired();
    }
}