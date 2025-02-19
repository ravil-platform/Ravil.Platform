namespace Application.Features.Category.Queries.GetRelatedRegion;

public class GetRelatedRegionQueryHandler : IRequestHandler<GetRelatedRegionQuery, List<RelatedCategorySeo>>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }
    public GetRelatedRegionQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<List<RelatedCategorySeo>>> Handle(GetRelatedRegionQuery request, CancellationToken cancellationToken)
    {
        var relatedCategoryCities = 
            await UnitOfWork.RelatedCategorySeoRepository.TableNoTracking
                .Where(r => r.CurrentCityId == request.CurrentCityId)
                .ToListAsync(cancellationToken);

        return relatedCategoryCities;
    }
}