namespace Domain.Entities.Account
{
    public class AccountCategory : BaseEntity
    {
        #region (Fields)
        public string Title { get; set; } = null!;

        public string IconPicture { get; set; } = null!;

        public bool Status { get; set; }

        public short Sort { get; set; }
        #endregion

        #region (Relations)
        public virtual ICollection<Account> Accounts { get; set; }
        #endregion
    }
}