using AngleSharp.Attributes;
using Domain.Entities.Histories.Enums;

namespace Application.Features.ActionHistories.Create
{
    public class CreateActionHistoriesCommand : IRequest
    {
        public int JobId { get; set; }
        public string JobBranchId { get; set; }
        public string Location { get; set; }
        public string? PhoneNumber { get; set; }
        public ActionType ActionType { get; set; }
    }
}
