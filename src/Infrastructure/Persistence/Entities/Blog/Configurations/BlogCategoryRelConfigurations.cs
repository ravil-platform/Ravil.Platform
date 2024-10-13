namespace Persistence.Entities.Blog.Configurations
{
    public class BlogCategoryRelConfigurations : IEntityTypeConfiguration<BlogCategoryRel>
    {
        public void Configure(EntityTypeBuilder<BlogCategoryRel> builder)
        {
            builder.ToTable("BlogCategoryRel", DatabaseSchemas.Blogs);

            builder.HasKey(b => b.Id);
        }
    }
}
