namespace Domain.Entities.Brand
{
    public class Brand : BaseEntity
    {
        #region (Fields)
        public string Title { get; set; } = null!;

        public string AlternateTitle { get; set; } = null!;

        public string Introduction { get; set; } = null!;

        public string SearchLink { get; set; } = null!;

        public string Picture { get; set; } = null!;

        public bool Status { get; set; }
        #endregion

        #region (Realtion)
        public virtual ICollection<Job.Job> Jobs { get; set; }
        #endregion
    }
}
