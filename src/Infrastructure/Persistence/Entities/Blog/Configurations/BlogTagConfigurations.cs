namespace Persistence.Entities.Blog.Configurations;

public class BlogTagConfigurations : IEntityTypeConfiguration<BlogTag>
{
    public void Configure(EntityTypeBuilder<BlogTag> builder)
    {
        builder.ToTable("BlogTags", "Blogs");

        builder.HasKey(b => b.Id);
    }
}