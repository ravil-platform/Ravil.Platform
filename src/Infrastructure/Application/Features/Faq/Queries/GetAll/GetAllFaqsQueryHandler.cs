using ViewModels.QueriesResponseViewModel.Faq;

namespace Application.Features.Faq.Queries.GetAll;

public class GetAllFaqsQueryHandler : IRequestHandler<GetAllFaqsQuery, List<FaqViewModel>>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }

    public GetAllFaqsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<List<FaqViewModel>>> Handle(GetAllFaqsQuery request, CancellationToken cancellationToken)
    {
        var result = await UnitOfWork.FaqRepository.GetAllAsync();

        var faqsViewModel = Mapper.Map<List<FaqViewModel>>(result);

        return faqsViewModel;
    }
}