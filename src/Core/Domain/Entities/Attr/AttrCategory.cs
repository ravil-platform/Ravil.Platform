using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Attr
{
    public class AttrCategory
    {
        #region (Fields)
        [Key]
        [Display(Name = "شناسه")]
        public int Id { get; set; }

        [Display(Name = "عنوان دسته ویژگی")]
        [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
        [StringLength(256, MinimumLength = 3, ErrorMessage = "{0} باید بین {2} تا {1} کاراکتر باشد.")]
        public string Title { get; set; }

        [Display(Name = "آیکون | تصویر")]
        [StringLength(50)]
        public string IconPicture { get; set; }//TODO Set This Section

        [Display(Name = "وضعیت")]
        [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
        public bool Status { get; set; }

        [Display(Name = "ترتیب")]
        [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
        public short Sort { get; set; }
        #endregion


        #region (Relations)
        public virtual ICollection<Attr> Attributes { get; set; }
        public virtual ICollection<AttrAccount> AttributeAccounts { get; set; }
        #endregion
    }
}
