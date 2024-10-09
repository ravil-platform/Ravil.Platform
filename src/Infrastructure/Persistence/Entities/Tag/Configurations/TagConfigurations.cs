namespace Persistence.Entities.Tag.Configurations
{
    public class TagConfigurations : IEntityTypeConfiguration<Domain.Entities.Tag.Tag>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Tag.Tag> builder)
        {
            builder.ToTable("Tags", "Tags");

            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).IsRequired().HasMaxLength(MaxLength.Name);
            builder.Property(t => t.UniqueName).IsRequired().HasMaxLength(MaxLength.Slug);
            builder.Property(t => t.Status).IsRequired();
            builder.Property(t => t.IconPicture).IsRequired(false).HasMaxLength(MaxLength.Picture);
            builder.Property(t => t.IconHtmlCode).IsRequired(false).HasMaxLength(MaxLength.Picture);

            //relations 
            builder
                .HasMany(t => t.JobTags)
                .WithOne(t => t.Tag)
                .HasForeignKey(j => j.TagId)
                .IsRequired();

            builder
                .HasMany(t => t.BlogTags)
                .WithOne(t => t.Tag)
                .HasForeignKey(j => j.TagId)
                .IsRequired();

            builder
                .HasMany(t => t.JobBranchTags)
                .WithOne(t => t.Tag)
                .HasForeignKey(j => j.TagId)
                .IsRequired();
        }
    }
}
