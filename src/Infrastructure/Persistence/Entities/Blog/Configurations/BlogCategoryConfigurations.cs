namespace Persistence.Entities.Blog.Configurations
{
    public class BlogCategoryConfigurations : IEntityTypeConfiguration<BlogCategory>
    {
        public void Configure(EntityTypeBuilder<BlogCategory> builder)
        {
            builder.ToTable("BlogCategory", DatabaseSchemas.Blogs);

            builder.HasKey(b => b.Id);
            builder.Property(b => b.Title).IsRequired().HasMaxLength(MaxLength.Title);
            builder.Property(b => b.Sort).IsRequired();

            //relations
            builder
                .HasMany(b => b.BlogCategoryRels)
                .WithOne(b => b.BlogCategory)
                .HasForeignKey(b => b.BlogCategoryId);
        }
    }
}
