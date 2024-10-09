namespace Domain.Entities.Job
{
    public class JobSelectionSlider
    {
        #region (Fields)
        public int Id { get; set; }

        public JobSliderType JobSliderType { get; set; }
        #endregion

        #region (Relations)
        public int JobId { get; set; }

        public string JobBranchId { get; set; }
        public virtual JobBranch JobBranch { get; set; }
        #endregion
    }
}
