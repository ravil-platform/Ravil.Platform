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
        var result = await UnitOfWork.FaqJobCategoryRepository.TableNoTracking.Include(a => a.Faq)
            .Where(f => f.JobCategoryId == request.CategoryId)
            .Select(f => f.Faq).Take(10)
            .ToListAsync(cancellationToken: cancellationToken);

        var faqsViewModel = Mapper.Map<List<FaqViewModel>>(result);

        return faqsViewModel;
    }
}