using Persistence.Entities.Comment.Repositories.Interfaces;

namespace Persistence.Entities.Comment.Repositories.Implementations;

public class CommentRepository : Repository<Domain.Entities.Comment.Comment>, ICommentRepository
{
    internal CommentRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}