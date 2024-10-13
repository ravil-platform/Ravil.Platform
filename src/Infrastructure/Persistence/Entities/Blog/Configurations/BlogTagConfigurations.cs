namespace Persistence.Entities.Blog.Configurations;

public class BlogTagConfigurations : IEntityTypeConfiguration<BlogTag>
{
    public void Configure(EntityTypeBuilder<BlogTag> builder)
    {
        builder.ToTable("BlogTag", DatabaseSchemas.Blogs);

        builder.HasKey(b => b.Id);
    }
}