namespace Application.Features.Comment.Queries.GetAll;

public class GetCommentsByFilterQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    : IRequestHandler<GetCommentsByFilterQuery, List<CommentViewModel>>
{
    #region ( Dependencies )

    protected IMapper Mapper { get; } = mapper;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;

    #endregion

    public async Task<Result<List<CommentViewModel>>> Handle(GetCommentsByFilterQuery request, CancellationToken cancellationToken)
    {
        #region ( Get Comments By Filter Query )

        var query = UnitOfWork.CommentRepository.TableNoTracking;

        #region ( Filters )
        if (request.IsConfirmed.HasValue)
        {
            query = query.Where(c => c.IsConfirmed == request.IsConfirmed.Value);
        }

        if (request.HasAnswered.HasValue)
        {
            query = query.Include(a => a.AnswerComments)
                .Where(c => c.AnswerComments.Any(a => a.IsConfirmed));
        }

        if (request.CommentType != null)
        {
            query = query.Where(c => c.CommentType == request.CommentType);
        }

        if (request.JobBranchId != null)
        {
            if (!string.IsNullOrWhiteSpace(request.BusinessOwnerId))
            {
                var businessOwner = await UnitOfWork.JobBranchRepository.TableNoTracking
                    .Where(a => a.UserId != null && a.UserId.Equals(request.BusinessOwnerId))
                    .SingleOrDefaultAsync(a => a.Id == request.JobBranchId, cancellationToken: cancellationToken);

                if (businessOwner is not null)
                {
                    query = query.Where(c => c.JobBranchId == businessOwner.Id);
                    query = query.Where(c => c.CommentType == CommentTypes.JobBranch);
                }
            }
            else
            {
                query = query.Where(c => c.JobBranchId == request.JobBranchId);
            }
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
            query = query.Include(a => a.AnswerComments)
                .Take((int)request.Take).AsQueryable();
        }
        #endregion

        var result = await query.ToListAsync(cancellationToken);

        var commentViewModels = Mapper.Map<List<CommentViewModel>>(result);

        return commentViewModels;

        #endregion
    }
}