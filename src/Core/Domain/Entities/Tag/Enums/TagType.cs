namespace Domain.Entities.Tag.Enums;

public enum TagType
{
    [Display(Name = "مخصوص اکانت")]
    Account,
    [Display(Name = "مخصوص کسب و کار")]
    JobBranch,
    [Display(Name = "مخصوص وبلاگ")]
    Blog,
    [Display(Name = "مخصوص شهر")]
    City
}