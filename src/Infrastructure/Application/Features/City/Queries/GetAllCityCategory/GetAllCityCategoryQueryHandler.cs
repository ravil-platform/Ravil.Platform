using ViewModels.QueriesResponseViewModel.City;

namespace Application.Features.City.Queries.GetAllCityCategory;

public class GetAllCityCategoryQueryHandler : IRequestHandler<GetAllCityCategoryQuery, List<CityCategoryViewModel>>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }

    public GetAllCityCategoryQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<List<CityCategoryViewModel>>> Handle(GetAllCityCategoryQuery request, CancellationToken cancellationToken)
    {
        var result = await UnitOfWork.CityCategoryRepository.GetAllAsync();

        var cityCategoryViewModel = Mapper.Map<List<CityCategoryViewModel>>(result);

        return cityCategoryViewModel;
    }
}