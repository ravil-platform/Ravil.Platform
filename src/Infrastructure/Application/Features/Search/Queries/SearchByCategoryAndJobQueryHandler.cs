using ViewModels.QueriesResponseViewModel.Search;

namespace Application.Features.Search.Queries;

public class SearchByCategoryAndJobQueryHandler : IRequestHandler<SearchByCategoryAndJobQuery,
    SearchByCategoryAndJobQueryViewModel>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }
    public SearchByCategoryAndJobQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<SearchByCategoryAndJobQueryViewModel>> Handle(SearchByCategoryAndJobQuery request, CancellationToken cancellationToken)
    {
        var jobs = await UnitOfWork.JobRepository.SearchJob(request.Name, request.CityName);

        #region ( Mapping )
        var jobsViewModel = Mapper.Map<List<JobSearchResultViewModel>>(jobs);
        #endregion

        var result = new SearchByCategoryAndJobQueryViewModel();
        result.Jobs = jobsViewModel;

        return result;
    }
}