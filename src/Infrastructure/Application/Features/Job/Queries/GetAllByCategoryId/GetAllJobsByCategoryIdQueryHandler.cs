using AutoMapper;
using FluentResults;
using Persistence.Contracts;
using RNX.Mediator;
using ViewModels.QueriesResponseViewModel.Job;

namespace Application.Features.Job.Queries.GetAllByCategoryId;

public class GetAllJobsByCategoryIdQueryHandler : IRequestHandler<GetAllJobsByCategoryIdQuery, List<JobViewModel>>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }

    public GetAllJobsByCategoryIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<List<JobViewModel>>> Handle(GetAllJobsByCategoryIdQuery request, CancellationToken cancellationToken)
    {
        var jobs = await UnitOfWork.JobRepository.GetJobsByCategoryId(request.CategoryId, request.Take);

        var jobViewModel = Mapper.Map<List<JobViewModel>>(jobs);

        return jobViewModel;
    }
}