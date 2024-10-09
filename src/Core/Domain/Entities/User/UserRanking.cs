namespace Domain.Entities.User
{
    public class UserRanking
    {
        #region (Fields)
        public int Id { get; set; }
        [Display(Name = "ترتیب دلخواه")]

        public byte Sort { get; set; }


        [Display(Name = "تاکی ترتیب داشته باشد؟")]
        public int ExpireSortDay { get; set; }


        [Display(Name = "تاریخ ثبت نام")]
        public DateTime RegisterDate { get; set; } = DateTime.Now;


        [Display(Name = "تاریخ بروزرسانی")]
        public DateTime LastUpdateDate { get; set; } = DateTime.Now;

        public string UpdateReason { get; set; }


        [Display(Name = "سابقه")]
        public long RegisterHistoryDay { get; set; }


        [Display(Name = "تعداد کسب و کار")]
        public int JobCount { get; set; }


        [Display(Name = "تعداد امتیازدهی")]
        public long ReviewCount { get; set; }


        [Display(Name = "تعداد اشتراک گذاری")]
        public int SharedCount { get; set; }


        [Display(Name = "تعداد کامنت")]
        public int CommentCount { get; set; }


        [Display(Name = "تعداد بازدید")]
        public int ViewCount { get; set; } = 0;


        [Display(Name = "مجموع امتیازات")]
        public long TotalScore { get; set; } = 0;

        #endregion

        #region (Relations)
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        #endregion
    }
}
