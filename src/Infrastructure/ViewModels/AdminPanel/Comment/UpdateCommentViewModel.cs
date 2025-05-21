namespace ViewModels.AdminPanel.Comment
{
    public class UpdateCommentViewModel
    {
        public int Id { get; set; }

        [Display(Name = nameof(DisplayNames.FullName), ResourceType = typeof(DisplayNames))]
        [Required(ErrorMessageResourceName = nameof(Validations.Required),
            ErrorMessageResourceType = typeof(Validations))]
        public string FullName { get; set; } = null!;

        [Display(Name = nameof(DisplayNames.CellPhoneNumber), ResourceType = typeof(DisplayNames))]
        [Required(ErrorMessageResourceName = nameof(Validations.Required),
            ErrorMessageResourceType = typeof(Validations))]
        public string Phone { get; set; } = null!;

        [Display(Name = "متن کامنت")]
        [Required(ErrorMessage = "پر کردن {0} الزامی است.")]
        public string CommentText { get; set; } = null!;

    }
}
