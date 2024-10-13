namespace Domain.Entities.User
{
    public class UserBannerView : IEntity
    {
        #region (Fields)
        public int Id { get; set; }
        #endregion

        #region (Relations)
        public int BannerId { get; set; }
        public virtual Banner.Banner Banner { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        #endregion
    }
}