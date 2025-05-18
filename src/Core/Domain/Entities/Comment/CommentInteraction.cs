namespace Domain.Entities.Comment
{
    public class CommentInteraction : BaseEntity
    {
        #region ( Fields )
        
        public long Id { get; set; }
        public string? UserId { get; set; }
        public bool Liked { get; set; }
        public bool DisLiked { get; set; }
        public string IpAddress { get; set; }

        #endregion

        #region ( Relations )
        public int CommentId { get; set; }
        public virtual Comment Comment { get; set; }
        #endregion
    }
}
