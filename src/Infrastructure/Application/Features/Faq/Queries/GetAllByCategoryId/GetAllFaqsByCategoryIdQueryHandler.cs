using ViewModels.QueriesResponseViewModel.Faq;

namespace Application.Features.Faq.Queries.GetAllByCategoryId;

public class GetAllFaqsByCategoryIdQueryHandler : IRequestHandler<GetAllFaqsByCategoryIdQuery, List<FaqViewModel>>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }

    public GetAllFaqsByCategoryIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<List<FaqViewModel>>> Handle(GetAllFaqsByCategoryIdQuery request, CancellationToken cancellationToken)
    {
        var result = await UnitOfWork.FaqRepository.GetAllAsync(f => f.CategoryId == request.CategoryId);

        var faqsViewModel = Mapper.Map<List<FaqViewModel>>(result);

        return faqsViewModel;
    }
}