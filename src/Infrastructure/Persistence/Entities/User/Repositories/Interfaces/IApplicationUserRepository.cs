namespace Persistence.Entities.User.Repositories.Interfaces;

public interface IApplicationUserRepository : IRepository<ApplicationUser>
{
    UsersFilterViewModel GetUsersByFilter(UsersFilterViewModel usersFilterViewModel);

    Task RemoveAsync(Guid id);
    Task DeleteAsync(Guid id);
    Task RestoreAsync(Guid id);

    Task ConfirmPhoneAsync(Guid id);
    Task UnConfirmPhoneAsync(Guid id);

    Task ConfirmEmailAsync(Guid id);
    Task UnConfirmEmailAsync(Guid id);

    Task<bool> LockAsync(Guid id, string lockoutReason, UserManager<ApplicationUser> UserManager);
    Task<bool> UnLockAsync(Guid id, UserManager<ApplicationUser> UserManager);
}