namespace Persistence.Entities.User.Repositories;

public interface IApplicationUserRepository : IRepository<ApplicationUser>
{
    UsersFilterViewModel GetUsersByFilter(UsersFilterViewModel usersFilterViewModel);


}