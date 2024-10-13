namespace Persistence.Entities.Faq.Configurations
{
    public class FaqCategoryConfigurations : IEntityTypeConfiguration<FaqCategory>
    {
        public void Configure(EntityTypeBuilder<FaqCategory> builder)
        {
            builder.ToTable("FaqCategory", DatabaseSchemas.Faqs);

            builder.HasKey(d => d.Id);
            builder.Property(d => d.Title).IsRequired().HasMaxLength(MaxLength.Title);
            builder.Property(d => d.Sort).IsRequired();
            builder.Property(d => d.Sort).IsRequired();
            builder.Property(d => d.ParentId).IsRequired();

            builder
                .HasMany(f => f.Faqs)
                .WithOne(f => f.FaqCategory)
                .HasForeignKey(f => f.CategoryId)
                .IsRequired();
        }
    }
}
