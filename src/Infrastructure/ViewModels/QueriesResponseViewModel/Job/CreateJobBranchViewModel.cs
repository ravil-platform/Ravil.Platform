namespace ViewModels.QueriesResponseViewModel.Job;

public class CreateJobBranchViewModel
{
    public string? Route { get; set; } = null!;
    public string? Title { get; set; } = null!;
    public string? HeadingTitle { get; set; }
    public string Description { get; set; } = null!;
    public string? BranchContent { get; set; }
    public IFormFile? BranchVideo { get; set; }
    public IFormFile? LargePictureFile { get; set; }
    public IFormFile? SmallPictureFile { get; set; }

    public string? MapUrl { get; set; }

    public bool? IsOffer { get; set; }
    public JobTimeWorkType? JobTimeWorkType { get; set; }
    public string? UserId { get; set; }
    public string? AddressId { get; set; }

    public List<IFormFile>? Gallery { get; set; }

}