namespace Application.Features.Job.Commands.CreateJobCategory;

public class CreateJobCategoryCommandHandler : IRequestHandler<CreateJobCategoryCommand>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }

    public CreateJobCategoryCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateJobCategoryCommand request, CancellationToken cancellationToken)
    {
        var jobCategory = Mapper.Map<JobCategory>(request);

        await UnitOfWork.JobCategoryRepository.InsertAsync(jobCategory);
        await UnitOfWork.SaveAsync();

        return new Result();
    }
}