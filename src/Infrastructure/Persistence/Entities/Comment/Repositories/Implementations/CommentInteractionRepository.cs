using Persistence.Entities.Comment.Repositories.Interfaces;

namespace Persistence.Entities.Comment.Repositories.Implementations;

public class CommentInteractionRepository : Repository<CommentInteraction>, ICommentInteractionRepository
{
    internal CommentInteractionRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}