namespace Persistence.Entities.Comment.Repositories;

public class CommentRepository : Repository<Domain.Entities.Comment.Comment>, ICommentRepository
{
    internal CommentRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}