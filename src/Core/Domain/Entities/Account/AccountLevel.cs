namespace Domain.Entities.Account
{
    public class AccountLevel : Entity
    {
        #region (Fields)
        public string LevelTitle { get; set; } = null!;

        public string LevelStyle { get; set; } = null!;
        #endregion

        #region (Relations)
        public virtual required ICollection<Account> Accounts { get; set; }
        #endregion
    }
}
