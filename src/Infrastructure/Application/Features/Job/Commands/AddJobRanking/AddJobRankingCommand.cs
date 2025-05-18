namespace Application.Features.Job.Commands.AddJobRanking
{
    public class AddJobRankingCommand : IRequest
    {
        public AddJobRankingCommandData[] Data { get; set; } = null!;
    }
}
