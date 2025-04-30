namespace ViewModels.AdminPanel.Job;

public class CreateJobBranchImageGalleryViewModel
{
    public string JobBranchId { get; set; } = null!;
    public IFormFileCollection Files { get; set; } = null!;
}