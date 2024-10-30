using Domain.Entities.Brand;

namespace Application.Features.Brand.Queries.GetAll;

public class GetAllBrandsQueryHandler : IRequestHandler<GetAllBrandsQuery, List<BrandViewModel>>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }
    public GetAllBrandsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<List<BrandViewModel>>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
    {
        var result = await UnitOfWork.BrandRepository.GetAllAsync(b => b.Status);

        var brandsViewModel = Mapper.Map<List<BrandViewModel>>(result);

        return brandsViewModel;
    }
}