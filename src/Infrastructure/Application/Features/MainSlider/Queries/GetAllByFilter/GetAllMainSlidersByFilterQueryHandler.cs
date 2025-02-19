namespace Application.Features.MainSlider.Queries.GetAllByFilter;

public class GetAllMainSlidersByFilterQueryHandler : IRequestHandler<GetAllMainSlidersByFilterQuery,
    List<MainSliderViewModel>>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }

    public GetAllMainSlidersByFilterQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<List<MainSliderViewModel>>> Handle(GetAllMainSlidersByFilterQuery request, CancellationToken cancellationToken)
    {
        if (request.BranchId != null)
        {
            var result = await UnitOfWork.MainSliderRepository.GetAllByJobBranchId(request.BranchId!, request.Take);

            var mainSliderViewModels = Mapper.Map<List<MainSliderViewModel>>(result);

            return mainSliderViewModels;
        }
        else if (request.StateId != null)
        {
            var result = await UnitOfWork.MainSliderRepository.GetAllByCityId((int)request.StateId, request.Take);

            var mainSliderViewModels = Mapper.Map<List<MainSliderViewModel>>(result);

            return mainSliderViewModels;
        }
        else if (request.CityId != null)
        {
            var result = await UnitOfWork.MainSliderRepository.GetAllByStateId((int)request.CityId, request.Take);

            var mainSliderViewModels = Mapper.Map<List<MainSliderViewModel>>(result);

            return mainSliderViewModels;
        }
        else
        {
            var result = await UnitOfWork.MainSliderRepository.TableNoTracking
                .Include(a => a.JobBranch).ThenInclude(a => a.Job)
                .Include(a => a.JobBranch.Address)
                .Take(request.Take).ToListAsync(cancellationToken);

            var mainSliderViewModels = Mapper.Map<List<MainSliderViewModel>>(result);

            return mainSliderViewModels;
        }
    }
}