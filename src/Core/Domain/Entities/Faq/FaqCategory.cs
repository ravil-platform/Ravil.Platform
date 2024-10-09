namespace Domain.Entities.Faq;
public class FaqCategory
{
    #region (Fields)
    [Key]
    public int Id { get; set; }


    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    [StringLength(256, MinimumLength = 3, ErrorMessage = "{0} باید بین {2} تا {1} کاراکتر باشد.")]
    public string Title { get; set; }


    [Display(Name = "ترتیب")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    public byte Sort { get; set; }

    [Display(Name = "دسته والد")]
    [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
    public int ParentId { get; set; }
    #endregion

    #region (Relations)
    public virtual ICollection<Faq> Faqs { get; set; }
    #endregion
}

