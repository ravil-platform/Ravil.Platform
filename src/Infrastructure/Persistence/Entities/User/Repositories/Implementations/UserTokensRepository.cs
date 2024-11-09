using System.Security.Cryptography;

namespace Persistence.Entities.User.Repositories.Implementations
{
    internal class UserTokensRepository : Repository<UserTokens>, IUserTokensRepository
    {
        protected ApplicationDbContext ApplicationDbContext { get; }

        internal UserTokensRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            ApplicationDbContext = applicationDbContext;
        }
    }
}