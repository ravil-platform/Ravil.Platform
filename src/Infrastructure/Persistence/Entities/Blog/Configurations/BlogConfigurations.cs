namespace Persistence.Entities.Blog.Configurations
{
    public class BlogConfigurations : IEntityTypeConfiguration<Domain.Entities.Blog.Blog>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Blog.Blog> builder)
        {
            builder.ToTable("Blogs", "Blogs");

            builder.HasKey(b => b.Id);
            builder.Property(b => b.Route).IsRequired().HasMaxLength(MaxLength.Slug);
            builder.Property(b => b.Title).IsRequired().HasMaxLength(MaxLength.Title);
            builder.Property(b => b.SubTitle).IsRequired().HasMaxLength(MaxLength.Title);
            builder.Property(b => b.Summary).IsRequired().HasMaxLength(MaxLength.Summary);
            builder.Property(b => b.TitleListContent).IsRequired(false);
            builder.Property(b => b.ReadingTime).IsRequired(false);
            builder.Property(b => b.Content).IsRequired().HasMaxLength(MaxLength.Content);
            builder.Property(b => b.LargePicture).IsRequired(false).HasMaxLength(MaxLength.Picture);
            builder.Property(b => b.SmallPicture).IsRequired(false).HasMaxLength(MaxLength.Picture);
            builder.Property(b => b.IsResizePicture).IsRequired();
            builder.Property(b => b.ViewCount).IsRequired(false);
            builder.Property(b => b.AuthorName).IsRequired().HasMaxLength(MaxLength.Name);

            //relations
            builder
                .HasMany(b => b.BlogTags)
                .WithOne(b => b.Blog)
                .HasForeignKey(b => b.BlogId);

            builder
                .HasMany(b => b.BlogCategoryRels)
                .WithOne(b => b.Blog)
                .HasForeignKey(b => b.BlogId);

            builder
                .HasMany(b => b.BlogUserActions)
                .WithOne(b => b.Blog)
                .HasForeignKey(b => b.BlogId);

            builder
                .HasMany(b => b.BlogUserLikes)
                .WithOne(b => b.Blog)
                .HasForeignKey(b => b.BlogId);


            builder
                .HasMany(b => b.BlogComments)
                .WithOne(b => b.Blog)
                .HasForeignKey(b => b.BlogId);
        }
    }
}
