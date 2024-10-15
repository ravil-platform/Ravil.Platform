namespace Persistence.Entities.User.Repositories;

public interface IApplicationUserRepository : IRepository<ApplicationUser>
{
    UsersFilterViewModel GetUsersByFilter(UsersFilterViewModel usersFilterViewModel);

    Task RemoveAsync(Guid id, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task RestoreAsync(Guid id, CancellationToken cancellationToken);

    Task ConfirmPhoneAsync(Guid id, CancellationToken cancellationToken);
    Task UnConfirmPhoneAsync(Guid id, CancellationToken cancellationToken);

    Task ConfirmEmailAsync(Guid id, CancellationToken cancellationToken);
    Task UnConfirmEmailAsync(Guid id, CancellationToken cancellationToken);

    Task LockAsync(Guid id, string lockoutReason, CancellationToken cancellationToken);
    Task UnLockAsync(Guid id, CancellationToken cancellationToken);
}