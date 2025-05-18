using Application.Features.Job.Commands.UpdateJobBranch;

namespace Application.Features.Job.Commands.UpdateBusiness;

public class UpdateBusinessCommand : IRequest<JobBranchViewModel>
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

    public int? IsEndWork { get; set; }

    public int StateId { get; set; }
    public int CityId { get; set; }

    /// <summary>
    /// طول جغرافیایی
    /// </summary>
    public double Lat { get; set; } = 0.00;

    /// <summary>
    /// عرض جغرافیایی
    /// </summary>
    public double Long { get; set; } = 0.00;

    /// <summary>
    /// آدرس
    /// </summary>
    public string FullAddress { get; set; } = null!;

    /// <summary>
    /// آدرس پستی
    /// </summary>
    public string? PostalAddress { get; set; }

    /// <summary>
    /// مجله یا شهرستان
    /// </summary>
    public string? Neighbourhood { get; set; }

    /// <summary>
    /// کد پستی
    /// </summary>
    public string? PostalCode { get; set; }
}