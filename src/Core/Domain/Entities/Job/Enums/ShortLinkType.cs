namespace Domain.Entities.Job.Enums;

public enum ShortLinkType
{
    [Display(Name = "مخصوص محصولات")]
    Product,
    [Display(Name = "مخصوص کسب و کار")]
    JobBranch,
    [Display(Name = "مخصوص وبلاگ")]
    Blog
}