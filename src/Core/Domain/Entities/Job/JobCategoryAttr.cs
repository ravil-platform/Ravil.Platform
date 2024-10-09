namespace Domain.Entities.Job
{
    [NotMapped]
    public class JobCategoryAttr
    {
        #region (Fields)
        public int Id { get; set; }
        #endregion

        #region (Relations)
        [Required]
        public int JobCategoryId { get; set; }
        public virtual JobCategory JobCategory { get; set; }


        [Required]
        public int AttrId { get; set; }
        public virtual Attr.Attr Attr { get; set; }
        #endregion
    }
}