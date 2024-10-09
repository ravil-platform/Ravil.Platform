namespace Domain.Entities.User
{
    public class Action
    {
        #region (Fields)
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public ActionTypes ActionTypes { get; set; }

        public int ActionScore { get; set; }

        public double? ActionPriceScore { get; set; }
        #endregion

        #region (Relations)
        public virtual ICollection<UserAction> UserActions { get; set; }
        #endregion
    }
}
