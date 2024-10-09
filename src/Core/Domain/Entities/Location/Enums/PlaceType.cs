namespace Domain.Entities.Location.Enums;

public enum PlaceType
{
    [Display(Name = "مسکونی")]
    Home,
    [Display(Name = "اداری")]
    Office,
    [Display(Name = "کشاورزی")]
    Farm,
    [Display(Name = "تجاری")]
    Business,
    [Display(Name = "سایر")]
    Other
}