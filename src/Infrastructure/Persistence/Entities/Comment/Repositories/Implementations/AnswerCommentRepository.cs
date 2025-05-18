using Persistence.Entities.Comment.Repositories.Interfaces;

namespace Persistence.Entities.Comment.Repositories.Implementations;

public class AnswerCommentRepository : Repository<AnswerComment>, IAnswerCommentRepository
{
    internal AnswerCommentRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}