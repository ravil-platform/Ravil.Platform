namespace Domain.Entities.Order.Enums;

public enum PromoCodeType
{
    [Display(Name = "درصد")]
    Percent,
    [Display(Name = "قیمت")]
    Amount
}