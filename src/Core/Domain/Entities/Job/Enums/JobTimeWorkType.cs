namespace Domain.Entities.Job.Enums;

public enum JobTimeWorkType
{
    [Display(Name = "این کسب وکار در تمام ساعات شبانه روز باز است")]
    WorkAllTime,
    [Display(Name = "از ساعات کاری این کسب وکار اطلاعی ندارم")]
    NotInformation,
    [Display(Name = "این کسب وکار فقط در ساعات خاصی باز است")]
    WorkSomeTime
}