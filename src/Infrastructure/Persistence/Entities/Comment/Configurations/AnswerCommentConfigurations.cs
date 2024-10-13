namespace Persistence.Entities.Comment.Configurations;

public class AnswerCommentConfigurations : IEntityTypeConfiguration<AnswerComment>
{
    public void Configure(EntityTypeBuilder<AnswerComment> builder)
    {
        builder.ToTable("AnswerComment", DatabaseSchemas.Comments);

        builder.HasKey(a => a.Id);
        builder.Property(a => a.IsAdminAnswer).IsRequired();
        builder.Property(a => a.AdminId).IsRequired(false);
        builder.Property(a => a.UserIp).IsRequired(false);
        builder.Property(a => a.UserId).IsRequired(false);
        builder.Property(a => a.AnswerCommentTitle).IsRequired(false).HasMaxLength(MaxLength.Title);
        builder.Property(a => a.AnswerCommentText).IsRequired(false).HasMaxLength(MaxLength.Comment);
        builder.Property(a => a.AnswerCommentDate).IsRequired();
        builder.Property(a => a.ReviewDate).IsRequired(false);
        builder.Property(a => a.IsConfirmed).IsRequired();
        builder.Property(a => a.Phone).IsRequired(false).HasMaxLength(MaxLength.Phone);
        builder.Property(a => a.Email).IsRequired(false);
        builder.Property(a => a.FullName).IsRequired(false);
        builder.Property(a => a.Avatar).IsRequired(false).HasMaxLength(MaxLength.Picture);

    }
}