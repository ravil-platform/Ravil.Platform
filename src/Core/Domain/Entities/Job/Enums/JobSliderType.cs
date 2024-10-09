namespace Domain.Entities.Job.Enums;

public enum JobSliderType
{
    [Display(Name = "جدیدترین ها")]
    LatestJobs,
    [Display(Name = "برترین ها")]
    TopScoreJobs,
    [Display(Name = "پیشنهاد لحظه ای")]
    MomentJobs
}