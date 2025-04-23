namespace Application.Features.User.Queries.GetJobBookMarks;

public class GetJobBookMarksQueryHandler : IRequestHandler<GetJobBookMarksQuery, List<JobBranchViewModel>>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }

    public GetJobBookMarksQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    
    public async Task<Result<List<JobBranchViewModel>>> Handle(GetJobBookMarksQuery request, CancellationToken cancellationToken)
    {
        #region ( Get Job BookMarks Query )

        var userBookMarks = await UnitOfWork.UserBookMarkRepository.TableNoTracking
            .Where(current => current.UserBookMarkType == UserBookMarkType.JobBranch)
            .Where(current => !string.IsNullOrWhiteSpace(current.JobBranchId))
            .Where(current => current.UserId.Equals(request.UserId))
            .ToListAsync(cancellationToken: cancellationToken);

        if (userBookMarks.Count == 0)
            return Result.Fail(Resources.Messages.Validations.NotFound);

        var jobBranches = await UnitOfWork.JobBranchRepository.TableNoTracking
            .Include(a => a.Job).Include(a => a.JobBranchGalleries)
            .Include(a => a.Address).ThenInclude(a => a.Location)
            .Where(j => userBookMarks.Select(a => a.JobBranchId).Contains(j.Id))
            .ToListAsync(cancellationToken: cancellationToken);

        if (jobBranches.Count == 0)
            return Result.Fail(Resources.Messages.Validations.NotFound);


        var result = Mapper.Map<List<JobBranchViewModel>>(jobBranches);
        return result;

        #endregion
    }
}