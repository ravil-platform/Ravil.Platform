namespace ViewModels.Discounts
{
    public class CreateDiscountViewModel
    {
        [Display(Name = nameof(DisplayNames.Title), ResourceType = typeof(DisplayNames))]
        [Required(ErrorMessageResourceName = nameof(Validations.Required), ErrorMessageResourceType = typeof(Validations))]
        [MaxLength(MaxLength.Title, ErrorMessageResourceName = nameof(Validations.Required), ErrorMessageResourceType = typeof(Validations))]
        public string Title { get; set; } = null!;


        [Display(Name = nameof(DisplayNames.Code), ResourceType = typeof(DisplayNames))]
        [Required(ErrorMessageResourceName = nameof(Validations.Required), ErrorMessageResourceType = typeof(Validations))]
        [MaxLength(MaxLength.Code, ErrorMessageResourceName = nameof(Validations.Required), ErrorMessageResourceType = typeof(Validations))]
        public string Code { get; set; } = null!;


        public string? ExpireDateString { get; set; }

        public double? Amount { get; set; }
        public double? CartMinimum { get; set; }
        public double? CartMaximum { get; set; }
        public short? Discount { get; set; }
        public short? UseCountLimit { get; set; }


        [Display(Name = nameof(DisplayNames.Type), ResourceType = typeof(DisplayNames))]
        [Required(ErrorMessageResourceName = nameof(Validations.Required), ErrorMessageResourceType = typeof(Validations))]
        public PromoCodeType Type { get; set; }


        [Display(Name = nameof(DisplayNames.ExpireDate), ResourceType = typeof(DisplayNames))]
        public DateTime? ExpireDate { get; set; }


        public bool IsUseLimit { get; set; }
        public bool IsActiveForDiscounts { get; set; }


        [Display(Name = nameof(DisplayNames.IsActive), ResourceType = typeof(DisplayNames))]
        [Required(ErrorMessageResourceName = nameof(Validations.Required), ErrorMessageResourceType = typeof(Validations))]
        public bool IsActive { get; set; }
    }
}
