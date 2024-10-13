namespace Domain.Entities.Job
{
    public class JobRanking : BaseEntity
    {
        #region (Fields)
        public int Id { get; set; }

        public byte Sort { get; set; }

        public int ExpireSortDay { get; set; }

        public DateTime RegisterDate { get; set; } = DateTime.Now;
        
        public DateTime LastUpdateDate { get; set; } = DateTime.Now;

        public long RegisterHistoryDay { get; set; }

        public long JobReviewCount { get; set; }

        public int JobSharedCount { get; set; }

        public int JobCommentCount { get; set; }

        public int ViewCount { get; set; } = 0;

        public long TotalScore { get; set; } = 0;
        #endregion

        #region (Relations)
        public string JobId { get; set; }
        public virtual Job Job { get; set; }
        #endregion
    }
}
