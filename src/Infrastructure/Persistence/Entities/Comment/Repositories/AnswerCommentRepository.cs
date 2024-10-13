namespace Persistence.Entities.Comment.Repositories;

public class AnswerCommentRepository : Repository<AnswerComment>, IAnswerCommentRepository
{
    internal AnswerCommentRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}