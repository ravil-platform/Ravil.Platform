namespace Domain.Entities.User
{
    public class UserLikedGallery : BaseEntity
    {
        #region (Fields)
        public UserLikedType UserLikedType { get; set; }

        public int? BlogId { get; set; }
        public string? JobBranchId { get; set; }
        public string? UserIp { get; set; }
        #endregion

        #region (Relations)

        public string UserId { get; set; } = null!;
        public virtual ApplicationUser ApplicationUser { get; set; }
        #endregion
    }
}