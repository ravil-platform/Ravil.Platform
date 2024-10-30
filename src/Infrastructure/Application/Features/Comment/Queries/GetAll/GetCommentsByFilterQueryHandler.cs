using Microsoft.EntityFrameworkCore;
using ViewModels.QueriesResponseViewModel.Comment;

namespace Application.Features.Comment.Queries.GetAll;

public class GetCommentsByFilterQueryHandler : IRequestHandler<GetCommentsByFilterQuery, List<CommentViewModel>>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }
    public GetCommentsByFilterQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<List<CommentViewModel>>> Handle(GetCommentsByFilterQuery request, CancellationToken cancellationToken)
    {
        var query = UnitOfWork.CommentRepository.TableNoTracking;

        if (request.IsConfirmed)
        {
            query = query.Where(c => c.IsConfirmed);
        }

        if (request.CommentType != null)
        {
            query = query.Where(c => c.CommentType == request.CommentType);
        }

        if (request.JobBranchId != null)
        {
            query = query.Where(c => c.JobBranchId == request.JobBranchId);
        }

        if (request.BlogId != null)
        {
            query = query.Where(c => c.BlogId == request.BlogId);
        }

        if (request.UserId != null)
        {
            query = query.Where(c => c.UserId == request.UserId);
        }

        if (request.Take != null)
        {
            query = query.Take((int)request.Take);
        }

        var result = await query.ToListAsync(cancellationToken);

        var commentViewModels = Mapper.Map<List<CommentViewModel>>(result);

        return commentViewModels;
    }
}