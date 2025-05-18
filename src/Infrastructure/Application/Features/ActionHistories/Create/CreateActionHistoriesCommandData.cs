using Domain.Entities.Histories.Enums;

namespace Application.Features.ActionHistories.Create;

public class CreateActionHistoriesCommandData
{
    public ActionType? ActionType { get; set; } = null!;
    public int JobId { get; set; }
    public string? UserId { get; set; } = null!;
    public string? JobBranchId { get; set; }
    public int? CategoryId { get; set; }
    public string? CategoryName { get; set; } = null!;
    public string Location { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public string PageTitle { get; set; } = null!;
    public string PageSlug { get; set; } = null!;
    public string PageUrl { get; set; } = null!;
    public bool? IsActiveAds { get; set; }
}