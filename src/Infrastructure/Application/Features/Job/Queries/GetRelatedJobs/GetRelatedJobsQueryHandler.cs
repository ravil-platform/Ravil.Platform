using AutoMapper;
using FluentResults;
using Persistence.Contracts;
using RNX.Mediator;
using ViewModels.QueriesResponseViewModel.Job;

namespace Application.Features.Job.Queries.GetRelatedJobs;

public class GetRelatedJobsQueryHandler : IRequestHandler<GetRelatedJobsQuery, List<JobViewModel>>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }

    public GetRelatedJobsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<List<JobViewModel>>> Handle(GetRelatedJobsQuery request, CancellationToken cancellationToken)
    {
        var jobs = await UnitOfWork.JobRepository.GetRelatedJobs(request.JobId, request.Take);

        var jobViewModel = Mapper.Map<List<JobViewModel>>(jobs);

        return jobViewModel;
    }
}