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
        ICollection<Domain.Entities.Faq.Faq?> result;

        if (request.Take.HasValue)
        {
            result = (await UnitOfWork.FaqRepository.TableNoTracking.Take(request.Take.Value)
                .ToListAsync(cancellationToken: cancellationToken))!;
        }
        else
        {
            result = await UnitOfWork.FaqRepository.GetAllAsync();
        }

        var faqsViewModel = Mapper.Map<List<FaqViewModel>>(result);

        return faqsViewModel;
    }
}