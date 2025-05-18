namespace Application.Features.ActionHistories.Create
{
    public class CreateActionHistoriesCommand : IRequest
    {
        public CreateActionHistoriesCommandData[] Data { get; set; } = null!;
    }
}
