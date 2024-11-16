namespace Application.Features.ActionHistories.Create;

public class CreateActionHistoriesCommandHandler : IRequestHandler<CreateActionHistoriesCommand>
{
    protected IUnitOfWork UnitOfWork { get; }
    protected IHttpContextAccessor HttpContextAccessor { get; }
    public CreateActionHistoriesCommandHandler(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
    {
        UnitOfWork = unitOfWork;
        HttpContextAccessor = httpContextAccessor;
    }

    public async Task<Result> Handle(CreateActionHistoriesCommand request, CancellationToken cancellationToken)
    {
        var result = new Result();

        var userIp = HttpContextAccessor.HttpContext.Connection.RemoteIpAddress?.ToString();

        var actionHistory = new Domain.Entities.Histories.ActionHistories();

        var job = await UnitOfWork.JobRepository.GetByPredicate(j => j.Id == request.JobId);

        if (job != null)
        {
            var category = await UnitOfWork.JobCategoryRepository.GetByPredicate(j => j.JobId == job.Id, "Category");

            actionHistory.AddressIp = userIp;

            actionHistory.JobId = job.Id.ToString();
            actionHistory.JobTitle = job.Title;

            if (category != null)
            {
                actionHistory.CategoryId = category.CategoryId;
                actionHistory.CategoryName = category.Category.Name;
            }

            actionHistory.Location = request.Location;
            actionHistory.Time = DateTime.Now;

            if (request.PhoneNumber is not null)
            {
                var user = await UnitOfWork.ApplicationUserRepository.GetByPredicate(j =>
                    j.PhoneNumber == request.PhoneNumber);

                if (user is not null)
                {
                    actionHistory.UserId = user.Id;
                    actionHistory.FullName = user.UserName;
                }
            }

            actionHistory.ActionType = request.ActionType.GetEnumDisplayName()!;

            await UnitOfWork.ActionHistoriesRepository.InsertAsync(actionHistory);
            await UnitOfWork.SaveAsync();

            result.WithSuccess("عملیات با موفقیت انجام شد");

            return result;
        }

        result.WithError("خطایی رخ داد");
        return result;
    }
}