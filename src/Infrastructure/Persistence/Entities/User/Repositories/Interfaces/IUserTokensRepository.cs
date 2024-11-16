namespace Persistence.Entities.User.Repositories.Interfaces
{
    public interface IUserTokensRepository : IRepository<UserTokens>
    {
        Task DeleteUserTokenAsync(string userId, Guid tokenId);
    }
}