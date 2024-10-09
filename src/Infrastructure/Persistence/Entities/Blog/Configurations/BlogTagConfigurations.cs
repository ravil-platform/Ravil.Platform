namespace Persistence.Entities.Blog.Configurations;

public class BlogTagConfigurations : IEntityTypeConfiguration<BlogTag>
{
    public void Configure(EntityTypeBuilder<BlogTag> builder)
    {
        builder.HasKey(b => b.Id);
    }
}