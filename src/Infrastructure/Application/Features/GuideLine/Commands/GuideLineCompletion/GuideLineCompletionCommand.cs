namespace Application.Features.GuideLine.Commands.GuideLineCompletion;

public class GuideLineCompletionCommand : IRequest<GuideLineCompletionViewModel>
{
    public string? JobBranchId { get; set; } = null!;
    public string? Title { get; set; }
    public string? Summary { get; set; }
    public string? Description { get; set; }
    public IFormFile? BranchVideo { get; set; }
    public IFormFile? LargePictureFile { get; set; }
    public IFormFile? SmallPictureFile { get; set; }
    public List<IFormFile>? Gallery { get; set; }

    public Guid[]? Keywords { get; set; }
    public string? JobTimeWorks { get; set; }
    public string? SocialMediaInfos { get; set; }
    public string? PhoneNumberInfos { get; set; }
    
    public int? CityId { get; set; }
    public int? StateId { get; set; }
    public double? Lat { get; set; } = 0.00;
    public double? Long { get; set; } = 0.00;
    public string? FullAddress { get; set; }
    public string? Neighbourhood { get; set; }
}