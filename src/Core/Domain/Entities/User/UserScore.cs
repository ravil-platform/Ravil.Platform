using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.User
{
    public class UserScore
    {
        #region (Fields)
        [Key]
        public int Id { get; set; }

        [Display(Name = "مجموع امتیاز، کسب و کار")]
        public int JobScoreTotal { get; set; }

        [Display(Name = "مجموع امتیاز، امتیازدهی به کسب و کار")]
        public int JobReviewScoreTotal { get; set; }

        [Display(Name = "مجموع امتیاز، اشتراک گذاری کسب و کار")]
        public int JobSharedScoreTotal { get; set; }

        [Display(Name = "مجموع امتیاز، کامنت به کسب و کار")]
        public int JobCommentScoreTotal { get; set; }

        [Display(Name = "مجموع امتیاز، بازدید از کسب و کار")]
        public int ViewScoreTotal { get; set; }

        [Display(Name = "مجموع امتیازات")]
        public int TotalScores { get; set; } = 0;
        #endregion

        #region (Relations)
        [ForeignKey(nameof(ApplicationUser))]
        [Display(Name = "کاربر")]
        [StringLength(450)]
        [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        #endregion
    }
}