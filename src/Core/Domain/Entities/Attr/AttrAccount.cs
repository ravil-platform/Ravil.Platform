using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Entities.Account;
using Domain.Entities.Attr.Enums;

namespace Domain.Entities.Attr
{
    public class AttrAccount
    {
        #region (Fields)
        [Key]
        [Display(Name = "شناسه")]
        public int Id { get; set; }


        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
        [StringLength(256, MinimumLength = 3, ErrorMessage = "{0} باید بین {2} تا {1} کاراکتر باشد.")]
        public string Title { get; set; }


        [Required]
        [Display(Name = "نوع ویژگی")]
        public AttributeType AttrType { get; set; } = AttributeType.Account;


        [Display(Name = "ترتیب")]
        [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
        public short Sort { get; set; }


        [Display(Name = "آیکون")]
        [StringLength(60)]
        public string IconPicture { get; set; }


        [Display(Name = "کد HTML آیکون")]
        public string IconHtmlCode { get; set; }
        #endregion

        #region (Relations)
        //[Required]
        [Display(Name = "گروه")]
        public int? AttrCategoryId { get; set; }


        public virtual AttrCategory AttrCategory { get; set; }

        //[Required]
        //[Display(Name = "دسته بندی")]
        //public int AccountId { get; set; }
        //public virtual Account Account { get; set; }
        public virtual ICollection<AttrAccountValue> AttrAccountValues { get; set; }


        public virtual ICollection<AccountAttr> AttrAccounts { get; set; }
        #endregion
    }
}
