namespace Domain.Entities.Comment.Enums
{
    public enum CommentTypes
    {
        [Display(Name = "مخصوص محصولات")]
        Product,
        [Display(Name = "مخصوص کسب و کار")]
        JobBranch,
        [Display(Name = "مخصوص وبلاگ")]
        Blog
    }
}
