namespace Persistence.Entities.Comment.Configurations;

public class CommentInteractionConfigurations : IEntityTypeConfiguration<CommentInteraction>
{
    public void Configure(EntityTypeBuilder<CommentInteraction> builder)
    {
        builder.ToTable(nameof(CommentInteraction), DatabaseSchemas.Comments);

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Liked).IsRequired();
        builder.Property(a => a.DisLiked).IsRequired();
        builder.Property(a => a.IpAddress).IsRequired();
        builder.Property(a => a.UserId).IsRequired(false);
    }
}