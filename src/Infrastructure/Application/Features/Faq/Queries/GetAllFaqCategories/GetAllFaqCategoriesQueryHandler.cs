namespace Application.Features.Faq.Queries.GetAllFaqCategories;

public class GetAllFaqCategoriesQueryHandler : IRequestHandler<GetAllFaqCategoriesQuery, List<FaqCategoryViewModel>>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }

    public GetAllFaqCategoriesQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }


    public async Task<Result<List<FaqCategoryViewModel>>> Handle(GetAllFaqCategoriesQuery request, CancellationToken cancellationToken)
    {
        var result = await UnitOfWork.FaqCategoryRepository.GetAllAsync();

        var faqCategoriesViewModels = Mapper.Map<List<FaqCategoryViewModel>>(result);

        return faqCategoriesViewModels;
    }
}