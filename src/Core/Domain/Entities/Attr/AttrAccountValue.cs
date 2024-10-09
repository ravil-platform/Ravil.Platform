using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Entities.Account;

namespace Domain.Entities.Attr
{
    public class AttrAccountValue
    {
        #region (Fields)
        [Key]
        public int Id { get; set; }


        [Display(Name = "مقدار ویژگی")]
        [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
        [StringLength(256, MinimumLength = 3, ErrorMessage = "{0} باید بین {2} تا {1} کاراکتر باشد.")]
        public string Value { get; set; }


        [Display(Name = "ترتیب")]
        [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
        public int Sort { get; set; }
        #endregion

        #region (Relations)
        public int AttrAccountId { get; set; }
        public virtual required AttrAccount AttrAccount { get; set; }


        public virtual required ICollection<AccountAttr> AccountAttrs { get; set; }
        #endregion
    }
}
