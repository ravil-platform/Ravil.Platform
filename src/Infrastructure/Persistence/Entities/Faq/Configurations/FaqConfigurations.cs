namespace Persistence.Entities.Faq.Configurations;

public class FaqConfigurations : IEntityTypeConfiguration<Domain.Entities.Faq.Faq>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Faq.Faq> builder)
    {
        builder.ToTable("Faq", DatabaseSchemas.Faqs);

        builder.HasKey(d => d.Id);
        builder.Property(d => d.Question).IsRequired();
        builder.Property(d => d.Answer).IsRequired();
        builder.Property(d => d.Sort).IsRequired();
        builder.Property(d => d.IconPicture).IsRequired(false).HasMaxLength(MaxLength.Picture);

        builder
            .HasOne(f => f.FaqCategory)
            .WithMany(f => f.Faqs)
            .HasForeignKey(f => f.CategoryId)
            .IsRequired();
    }
}

