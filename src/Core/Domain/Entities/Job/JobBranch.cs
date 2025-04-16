namespace Domain.Entities.Job;

public class JobBranch : BaseMetaDataEntity
{
    #region (Fields)
    public new string Id { get; set; } = "RL-".ToUpper() + Guid.NewGuid().ToString("N").ToLower();

    public string? Route { get; set; } = null!;


    public string? Title { get; set; } = null!;

    public string? HeadingTitle { get; set; }

    public string Description { get; set; } = null!;

    public string? BranchContent { get; set; }

    public string? BranchVideo { get; set; }

    public string? LargePicture { get; set; }

    public string? SmallPicture { get; set; }

    public bool IsConfirmedByAdmin { get; set; } = false;

    public DateTime? ConfirmationDate { get; set; }

    public string? MapUrl { get; set; }

    public int ViewCount { get; set; } = 0;

    public int AverageRate { get; set; } = 0;

    public string? AdminName { get; set; }

    public string? AdminId { get; set; }

    public bool IsOffer { get; set; }

    public bool IsAdminCreator { get; set; } = false;

    public bool IsResizePicture { get; set; } = false;

    public JobTimeWorkType JobTimeWorkType { get; set; }


    public JobBranchStatus? Status { get; set; }
    public string? RejectedReason { get; set; }
    #endregion

    #region (Relations)
    public int JobId { get; set; }
    public virtual required Job Job { get; set; }
    
    public string? UserId { get; set; } = null!;
    public virtual required ApplicationUser ApplicationUser { get; set; }

    public string? AddressId { get; set; } = null!;
    public virtual required Address.Address Address { get; set; }

    public virtual ICollection<Banner.Banner>? Banners { get; set; } 
    public virtual ICollection<Comment.Comment>? Comments { get; set; }
    public virtual ICollection<MainSlider.MainSlider>? MainSliders { get; set; }

    public virtual ICollection<JobBranchGallery>? JobBranchGalleries { get; set; }
    public virtual ICollection<JobBranchShortLink>? JobBranchShortLinks { get; set; }
    public virtual ICollection<JobBranchTag>? JobBranchTags { get; set; }
    public virtual ICollection<JobSelectionSlider>? JobSelectionSliders { get; set; }
    public virtual ICollection<JobService>? JobServices { get; set; }
    public virtual ICollection<JobTimeWork>? JobTimeWorks { get; set; }
    public virtual ICollection<JobKeyword> JobKeywords { get; set; }

    public virtual ICollection<UserBookMark>? JobUserBookMarks { get; set; }
    public virtual ICollection<UsersFeedbackSlider>? UsersFeedbackSliders { get; set; }
    #endregion
}