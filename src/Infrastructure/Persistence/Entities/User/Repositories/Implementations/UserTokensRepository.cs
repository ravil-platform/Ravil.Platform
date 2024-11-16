namespace Persistence.Entities.User.Repositories.Implementations
{
    internal class UserTokensRepository : Repository<UserTokens>, IUserTokensRepository
    {
        protected ApplicationDbContext ApplicationDbContext { get; }

        internal UserTokensRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            ApplicationDbContext = applicationDbContext;
        }

        public async Task DeleteUserTokenAsync(string userId, Guid tokenId)
        {
            var token = await ApplicationDbContext.UserToken.Where(t => t.Id == tokenId && t.UserId == userId)
                .SingleOrDefaultAsync();

            if (token is not null)
            {
                ApplicationDbContext.UserToken.Remove(token);
            }
        }
    }
}