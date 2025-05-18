namespace Domain.Entities.Job
{
    public class JobRanking : BaseEntity
    {
        #region (Fields)
        public int Id { get; set; }

        /// <summary>
        /// آدرس صفحه
        /// </summary>
        public string PageUrl { get; set; } = null!;

        /// <summary>
        /// میانگین جایگاه
        /// </summary>
        public double AveragePosition { get; set; }

        /// <summary>
        /// تعداد کلیک
        /// </summary>
        public int ClickCount { get; set; }
        #endregion

        #region (Relations)
        public int JobId { get; set; }
        public virtual Job Job { get; set; }
        #endregion
    }
}
