namespace Persistence.Entities.Faq.Configurations;

public class FaqJobCategoryConfigurations : IEntityTypeConfiguration<FaqJobCategory>
{
    public void Configure(EntityTypeBuilder<FaqJobCategory> builder)
    {
        builder.ToTable(nameof(FaqJobCategory), DatabaseSchemas.Faqs);

        builder.HasKey(d => d.Id);

        builder
            .HasOne(f => f.Faq)
            .WithMany(f => f.FaqJobCategories)
            .HasForeignKey(f => f.FaqId)
            .IsRequired();

        builder
            .HasOne(f => f.Category)
            .WithMany(f => f.FaqJobCategories)
            .HasForeignKey(f => f.JobCategoryId)
            .IsRequired();
    }
}