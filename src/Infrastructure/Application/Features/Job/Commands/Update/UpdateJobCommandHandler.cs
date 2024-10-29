using AutoMapper;
using FluentResults;
using Persistence.Contracts;
using RNX.Mediator;
using ViewModels.QueriesResponseViewModel.Job;

namespace Application.Features.Job.Commands.Update;

public class UpdateJobCommandHandler : IRequestHandler<UpdateJobCommand, JobViewModel>
{
    protected IUnitOfWork UnitOfWork { get; }
    protected IMapper Mapper { get; }
    public UpdateJobCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }

    public async Task<Result<JobViewModel>> Handle(UpdateJobCommand request, CancellationToken cancellationToken)
    {
        var currentJob = await UnitOfWork.JobRepository.GetByIdAsync(request.Id);

        var updatedJob = Mapper.Map(request, currentJob);


        currentJob.SocialMediaInfos = request.SocialMediaInfos.All(a => !string.IsNullOrWhiteSpace(a.SocialMediaLink))
            ? System.Text.Json.JsonSerializer.Serialize(request.SocialMediaInfos) : string.Empty;
        currentJob.PhoneNumberInfos = request.PhoneNumberInfos.All(a => !string.IsNullOrWhiteSpace(a.PhoneNumber))
            ? System.Text.Json.JsonSerializer.Serialize(request.PhoneNumberInfos) : string.Empty;

        currentJob.Route = !string.IsNullOrWhiteSpace(request.Route) ? request.Route : request.Title;
        currentJob.Route = await UnitOfWork.ShortLinkRepository.EncodePersianLink(currentJob.Route);

        await UnitOfWork.JobRepository.UpdateAsync(currentJob);
        await UnitOfWork.SaveAsync();

        var jobViewModel = Mapper.Map<JobViewModel>(updatedJob);

        return jobViewModel;
    }
}