namespace Domain.Entities.Category.Enums
{
    public enum CategoryBusinessType
    {
        [Display(Name = nameof(PersonalBrand))]
        PersonalBrand = 0,
        [Display(Name = nameof(BrandName))]
        BrandName = 1,
    }
}
