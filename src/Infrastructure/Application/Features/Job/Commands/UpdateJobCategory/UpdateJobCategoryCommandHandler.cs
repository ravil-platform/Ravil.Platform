namespace Application.Features.Job.Commands.UpdateJobCategory;

public class UpdateJobCategoryCommandHandler : IRequestHandler<UpdateJobCategoryCommand>
{
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }

    public UpdateJobCategoryCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateJobCategoryCommand request, CancellationToken cancellationToken)
    {
        var currentJobCategory = await UnitOfWork.JobCategoryRepository.GetByIdAsync(request.Id);

        Mapper.Map(request, currentJobCategory);

        await UnitOfWork.JobCategoryRepository.UpdateAsync(currentJobCategory);
        await UnitOfWork.SaveAsync();

        return new Result();
    }
}