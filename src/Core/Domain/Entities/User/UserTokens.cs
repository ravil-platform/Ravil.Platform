namespace Domain.Entities.User
{
    public class UserTokens : BaseEntity
    {
        public Guid Id { get; set; }

        public string UserId { get; set; } = null!;
        public string HashJwtToken { get; set; } = null!;
        public string HashRefreshToken { get; set; } = null!;
        public DateTime TokenExpireDate { get; set; }
        public DateTime RefreshTokenExpireDate { get; set; }
        public string Device { get; set; } = null!;
    }
}
