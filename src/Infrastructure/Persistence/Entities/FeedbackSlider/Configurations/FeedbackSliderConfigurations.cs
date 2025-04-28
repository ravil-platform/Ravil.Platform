namespace Persistence.Entities.FeedbackSlider.Configurations;

public class FeedbackSliderConfigurations : IEntityTypeConfiguration<Domain.Entities.FeedbackSlider.FeedbackSlider>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.FeedbackSlider.FeedbackSlider> builder)
    {
        builder.ToTable("FeedbackSlider", DatabaseSchemas.Shared);

        builder.HasKey(f => f.Id);
        builder.Property(f => f.CategoryId).IsRequired(false);
        builder.Property(f => f.UserName).IsRequired().HasMaxLength(MaxLength.Username);
        builder.Property(f => f.UserRole).IsRequired().HasMaxLength(MaxLength.Username);
        builder.Property(f => f.Description).IsRequired().HasMaxLength(MaxLength.Description);
        builder.Property(f => f.Sort).IsRequired();
        builder.Property(f => f.Picture).IsRequired().HasMaxLength(MaxLength.Picture);
    }
}

