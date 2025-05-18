using Domain.Entities.Subscription;

namespace Domain.Entities.Job;

public class Job : Entity
{
    #region (Fields)
    public string Route { get; set; }

    public string Title { get; set; }

    public string SubTitle { get; set; }

    public string Summary { get; set; }

    public string Content { get; set; }

    public string LargePicture { get; set; }

    public string SmallPicture { get; set; }

    public string Email { get; set; }

    public string WebSiteName { get; set; }

    #region Contact Informations
    public string PhoneNumberInfos { get; set; } //Json Format (PhoneNumberInfosVm)

    public string SocialMediaInfos { get; set; } //Json Format (SocialMediaInfosVm)

    #region Additional Info
    public bool? ShowPhoneTelInSite { get; set; }

    public bool? ShowFirstPhoneMobileInSite { get; set; }
    #endregion
    #endregion

    public bool IsResizePicture { get; set; } = false;

    public string AdminName { get; set; }

    public string AdminId { get; set; }

    public int ViewCountTotal { get; set; }

    public int AverageRate { get; set; }

    public bool IsGoogleData { get; set; } = false;


    public JobBranchStatus? Status { get; set; }
    public string RejectedReason { get; set; }
    #endregion

    #region (Relations)
    public int? JobBrandId { get; set; }
    public virtual Brand.Brand Brand { get; set; }

    public virtual JobRanking JobRanking { get; set; }

    public virtual ICollection<JobTag> JobTags { get; set; }

    public virtual ICollection<JobInfo> JobInfos { get; set; }

    public virtual ICollection<JobBranch> JobBranches { get; set; }

    public virtual ICollection<JobCategory> JobCategories { get; set; }

    public virtual ICollection<MessageBox.MessageBox> MessageBoxes { get; set; }

    public virtual ICollection<JobRankingHistory> JobRankingHistories { get; set; }

    public virtual ICollection<SubscriptionClick> JobSubscriptionClicks { get; set; }
    #endregion
}