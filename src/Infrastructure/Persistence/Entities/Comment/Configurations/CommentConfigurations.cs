namespace Persistence.Entities.Comment.Configurations
{
    public class CommentConfigurations : IEntityTypeConfiguration<Domain.Entities.Comment.Comment>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Comment.Comment> builder)
        {
            builder.ToTable(nameof(Comment), DatabaseSchemas.Comments);

            builder.HasKey(c => c.Id);

            builder.Property(c => c.CommentType).IsRequired();
            builder.Property(c => c.JobBranchId).IsRequired(false);
            builder.Property(c => c.BlogId).IsRequired(false);
            builder.Property(c => c.Email).IsRequired(false);
            builder.Property(c => c.IsConfirmed).IsRequired();
            builder.Property(c => c.CommentText).IsRequired().HasMaxLength(MaxLength.Comment);
            builder.Property(c => c.Phone).IsRequired().HasMaxLength(MaxLength.Phone);
            builder.Property(c => c.FullName).IsRequired().HasMaxLength(MaxLength.FullName);
            builder.Property(c => c.Avatar).IsRequired(false).HasMaxLength(MaxLength.Picture);
            builder.Property(c => c.UserIp).IsRequired(false).HasMaxLength(MaxLength.Ip);
            builder.Property(c => c.Rate).IsRequired(false).HasMaxLength(MaxLength.Rate);

            builder.Property(c => c.UpVotesCount).IsRequired(false).HasDefaultValue(0);
            builder.Property(c => c.DownVotesCount).IsRequired(false).HasDefaultValue(0);
            builder.Property(c => c.UpVoteLastUpdate).IsRequired(false);
            builder.Property(c => c.DownVoteLastUpdate).IsRequired(false);

            //relations
            builder
                .HasMany(c => c.AnswerComments)
                .WithOne(c => c.Comment)
                .HasForeignKey(c => c.CommentId)
                .IsRequired();

            builder
                .HasMany(c => c.CommentInteractions)
                .WithOne(c => c.Comment)
                .HasForeignKey(c => c.CommentId)
                .IsRequired();
        }
    }
}
