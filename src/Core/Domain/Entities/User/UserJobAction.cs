namespace Domain.Entities.User
{
    public class UserJobAction : BaseEntity
    {
        #region (Fields)
        public JobActionType JobActionType { get; set; }

        public int ActionScore { get; set; }

        public byte Rating { get; set; } = 0;

        public DateTime ActionDate { get; set; } = DateTime.Now;
        #endregion

        #region (Relations)
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public string JobBranchId { get; set; }
        public virtual JobBranch JobBranch { get; set; }

        public int ActionId { get; set; }
        #endregion
    }
}
