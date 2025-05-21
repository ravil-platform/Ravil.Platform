namespace Persistence.Entities.Comment.Repositories.Implementations;

public class CommentRepository : Repository<Domain.Entities.Comment.Comment>, ICommentRepository
{
    protected ApplicationDbContext ApplicationDbContext;
    internal CommentRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }

    public CommentFilterViewModel GetByFilter(CommentFilterViewModel filter)
    {
        var query =
            ApplicationDbContext.Comment
                .OrderByDescending(b => b.CreateDate)
                .AsQueryable();

        if (filter.FindAll)
        {
            #region ( Find All )
            filter.Build(query.Count()).SetEntities(query);

            return filter;
            #endregion
        }

        #region ( Filter )
        if (filter.IsConfirmed != null)
        {
            query = query.Where(a => a.IsConfirmed == filter.IsConfirmed);
        }

        if (!string.IsNullOrWhiteSpace(filter.Text))
        {
            query = query.Where(a => a.CommentText.Contains(filter.Text));
        }

        if (!string.IsNullOrWhiteSpace(filter.PhoneNumber))
        {
            query = query.Where(a => a.Phone.Contains(filter.PhoneNumber));
        }

        if (!string.IsNullOrWhiteSpace(filter.FullName))
        {
            query = query.Where(c => c.FullName.Contains(filter.FullName));
        }
        
        if (!string.IsNullOrWhiteSpace(filter.UserIp))
        {
            query = query.Where(c => c.UserIp.Contains(filter.UserIp));
        }

        if (filter.CommentType != null)
        {
            query = query.Where(a => a.CommentType == filter.CommentType);

        }
        #endregion

        filter.Build(query.Count()).SetEntities(query);

        return filter;
    }
}