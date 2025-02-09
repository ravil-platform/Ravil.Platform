namespace Application.Features.FeedbackSlider.Queries.GetAllByFilter;

public class GetAllFeedbackSliderByFilterQueryHandler : IRequestHandler<GetAllFeedbackSliderByFilterQuery, List<FeedbackSliderViewModel>>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }

    public GetAllFeedbackSliderByFilterQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }


    public async Task<Result<List<FeedbackSliderViewModel>>> Handle(GetAllFeedbackSliderByFilterQuery request, CancellationToken cancellationToken)
    {
        var result = await UnitOfWork.FeedbackSliderRepository.GetAllByFilter(request.Take, request.CategoryId);

        var feedbackSliderViewModel = Mapper.Map<List<FeedbackSliderViewModel>>(result);

        return feedbackSliderViewModel;
    }
}