namespace Persistence.Entities.Category.Configurations
{
    public class CategoryConfigurations : IEntityTypeConfiguration<Domain.Entities.Category.Category>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Category.Category> builder)
        {
            builder.ToTable("Category", DatabaseSchemas.Categories);

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Type).IsRequired().HasDefaultValue(CategoryBusinessType.BrandName); ;
            builder.Property(c => c.Name).IsRequired().HasMaxLength(MaxLength.Name);
            builder.Property(c => c.Route).IsRequired().HasMaxLength(MaxLength.Slug);
            builder.Property(c => c.NodeLevel).IsRequired();
            builder.Property(c => c.HeadingTitle).IsRequired(false).HasMaxLength(MaxLength.Title);
            builder.Property(c => c.IsActive).IsRequired();
            builder.Property(c => c.IsLastNode).IsRequired();
            builder.Property(c => c.HasAttribute).IsRequired();
            builder.Property(c => c.Picture).IsRequired(false).HasMaxLength(MaxLength.Picture);
            builder.Property(c => c.IconPicture).IsRequired(false).HasMaxLength(MaxLength.Picture);
            builder.Property(c => c.IsResizePicture).IsRequired();
            builder.Property(c => c.Sort).IsRequired();
            builder.Property(c => c.PageContent).IsRequired(false).HasMaxLength(MaxLength.Content);
            builder.Property(c => c.ViewCount).IsRequired();

            //relations 
            builder
                .HasMany(a => a.Attributes)
                .WithOne(a => a.Category)
                .HasForeignKey(a => a.CategoryId)
                .IsRequired();

            builder
                .HasMany(a => a.CategoryServices)
                .WithOne(a => a.Category)
                .HasForeignKey(a => a.CategoryId)
                .IsRequired();

            builder
                .HasMany(c => c.CityCategories)
                .WithOne(c => c.Category)
                .HasForeignKey(c => c.CategoryId);

            builder
                .HasMany(c => c.JobCategories)
                .WithOne(c => c.Category)
                .HasForeignKey(c => c.CategoryId);
        }
    }
}
