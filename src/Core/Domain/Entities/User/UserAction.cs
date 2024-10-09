namespace Domain.Entities.User
{
    public class UserAction : BaseEntity
    {
        #region (Fields)
        public string? JobBranchId { get; set; }

        public int? BlogId { get; set; }

        public int ActionScore { get; set; }

        public byte? Rating { get; set; }

        [Display(Name = "نوع عملیات کاربر")]
        [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
        public ActionTypes ActionTypes { get; set; }
        #endregion

        #region (Relations)
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int ActionId { get; set; }
        public virtual Action Action { get; set; }
        #endregion
    }
}
