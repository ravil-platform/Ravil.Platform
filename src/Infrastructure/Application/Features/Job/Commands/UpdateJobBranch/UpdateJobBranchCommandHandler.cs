namespace Application.Features.Job.Commands.UpdateJobBranch;

public class UpdateJobBranchCommandHandler : IRequestHandler<UpdateJobBranchCommand, UpdateJobBranchViewModel>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }
    public UpdateJobBranchCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result<UpdateJobBranchViewModel>> Handle(UpdateJobBranchCommand request, CancellationToken cancellationToken)
    {
        await UnitOfWork.JobBranchRepository.BeginTransactionAsync();

        var itemJobBranch = await UnitOfWork.JobBranchRepository.GetByIdAsync(request.JobBranchId);

        if (itemJobBranch.Id.Equals(null) || itemJobBranch.Id.Equals("0"))
        {
            throw new BadRequestException();
        }

        #region ( Job Branch Tag )

        var currentTags = await UnitOfWork.JobBranchTagRepository
            .GetAllAsync(j => j.JobBranchId.Equals(itemJobBranch.Id));

        if (currentTags.Any())
        {
            UnitOfWork.JobBranchTagRepository.RemoveRange(currentTags.AsEnumerable());
        }

        if (request.Tags != null && request.Tags.Length > 0)
        {
            foreach (var item in request.Tags)
            {
                await UnitOfWork.JobBranchTagRepository.InsertAsync(new JobBranchTag
                {
                    JobBranchId = itemJobBranch.Id,
                    TagId = item
                });
            }
        }
        #endregion

        #region ( Job Branch Service )
        var currentServices = await UnitOfWork.JobServiceRepository
            .GetAllAsync(j => j.JobBranchId.Equals(itemJobBranch.Id));

        if (currentServices.Any())
        {
            UnitOfWork.JobServiceRepository.RemoveRange(currentServices.AsEnumerable());
        }

        if (request.Services != null && request.Services.Length > 0)
        {
            foreach (var itemService in request.Services)
            {
                await UnitOfWork.JobServiceRepository.InsertAsync(new JobService()
                {
                    JobBranchId = itemJobBranch.Id,
                    ServiceId = itemService
                });
            }
        }
        #endregion

        #region ( Job Branch TimeWork )
        var currentJobTimeWorks = await UnitOfWork.JobTimeWorkRepository
            .GetAllAsync(j => j.JobBranchId.Equals(itemJobBranch.Id));

        if (currentJobTimeWorks.Any())
        {
            UnitOfWork.JobTimeWorkRepository.RemoveRange(currentJobTimeWorks.AsEnumerable());
        }

        if (request.JobTimeWork != null && request.JobTimeWork.Count > 0)
        {
            if (request.JobTimeWork.Count > 1)
            {
                foreach (var item in request.JobTimeWork)
                {
                    await UnitOfWork.JobTimeWorkRepository.InsertAsync(new JobTimeWork()
                    {
                        DayOfWeekId = item.DayOfWeekId,
                        JobBranchId = itemJobBranch.Id,
                        StartTime = item.StartTime,
                        EndTime = item.EndTime
                    });
                }
            }
            else
            {
                var item = request.JobTimeWork.First();

                if (!string.IsNullOrWhiteSpace(item.StartTime)
                    && !string.IsNullOrWhiteSpace(item.EndTime)
                    && !string.IsNullOrWhiteSpace(item.JobBranchId)
                    && item.DayOfWeekId > 0)
                {
                    await UnitOfWork.JobTimeWorkRepository.InsertAsync(new JobTimeWork()
                    {
                        DayOfWeekId = item.DayOfWeekId,
                        JobBranchId = itemJobBranch.Id,
                        StartTime = item.StartTime,
                        EndTime = item.EndTime
                    });
                }
            }
        }
        #endregion

        var updatedJobBranch = Mapper.Map(request.CreateJobBranchViewModel, itemJobBranch);

        updatedJobBranch.LastUpdateDate = DateTime.Now;
        updatedJobBranch.ConfirmationDate = DateTime.Now;

        await UnitOfWork.JobBranchRepository.UpdateAsync(updatedJobBranch);
        await UnitOfWork.SaveAsync();

        await UnitOfWork.JobBranchRepository.CommitTransactionAsync();


        var jobBranch = await UnitOfWork.JobBranchRepository
            .GetByPredicate(j => j.Id.Equals(updatedJobBranch.Id), "Job");


        var jobCategory = await UnitOfWork.JobCategoriesViewRepository
            .GetAllAsync(j => j.JobId.Equals(updatedJobBranch.JobId));


        var tags = await UnitOfWork.JobBranchTagRepository
            .GetAllAsync(j => j.JobBranchId.Equals(updatedJobBranch.Id));


        var services = await UnitOfWork.JobServiceRepository
            .GetAllAsync(j => j.JobBranchId.Equals(updatedJobBranch.Id));


        var jobBranchViewModel = Mapper.Map<JobBranchViewModel>(jobBranch);

        var result = new UpdateJobBranchViewModel
        {
            JobBranchViewModel = jobBranchViewModel,
            Tags = tags.Select(t => t.TagId).ToArray(),
            Services = services.Select(s => s.ServiceId).ToArray(),
            Categories = jobCategory.Select(j => j.CategoryId).ToArray()
        };

        return result;
    }
}