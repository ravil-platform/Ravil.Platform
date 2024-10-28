using Microsoft.AspNetCore.Identity;

namespace Persistence.Entities.User.Repositories.Implementations;

public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
{
    public ApplicationDbContext ApplicationDbContext { get; }

    internal ApplicationUserRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }

    public UsersFilterViewModel GetUsersByFilter(UsersFilterViewModel usersFilterViewModel)
    {
        var query = ApplicationDbContext.Users
            .OrderByDescending(a => a.RegisterDate).AsQueryable();

        if (usersFilterViewModel.FindAll)
        {
            #region (Find All Users)

            usersFilterViewModel.Build(query.Count()).SetEntities(query);

            return usersFilterViewModel;

            #endregion
        }

        #region (Filter)

        if (!string.IsNullOrWhiteSpace(usersFilterViewModel.Firstname))
        {
            query = query.Where(a => a.Firstname!.Contains(usersFilterViewModel.Firstname.Trim()));
        }

        if (!string.IsNullOrWhiteSpace(usersFilterViewModel.Lastname))
        {
            query = query.Where(a => a.Lastname!.Contains(usersFilterViewModel.Lastname.Trim()));
        }

        if (!string.IsNullOrWhiteSpace(usersFilterViewModel.NationalCode))
        {
            query = query.Where(a => a.NationalCode!.Contains(usersFilterViewModel.NationalCode.Trim()));
        }

        if (!string.IsNullOrWhiteSpace(usersFilterViewModel.Phone))
        {
            query = query.Where(a => a.Phone!.Contains(usersFilterViewModel.Phone.Trim()));
        }

        if (!string.IsNullOrWhiteSpace(usersFilterViewModel.UserName))
        {
            query = query.Where(a => a.UserName!.Contains(usersFilterViewModel.UserName.Trim()));
        }

        if (usersFilterViewModel.Active != null)
        {
            query = query.Where(a => a.PhoneNumberConfirmed == usersFilterViewModel.Active);
        }

        try
        {
            if (usersFilterViewModel.RegisterDateFrom != null)
            {
                var persianCalendar = new PersianCalendar();

                var year = usersFilterViewModel.RegisterDateFrom.Value.Year;
                var month = usersFilterViewModel.RegisterDateFrom.Value.Month;
                var day = usersFilterViewModel.RegisterDateFrom.Value.Day;

                var registerDateFrom = persianCalendar.ToDateTime(year, month, day, 00, 00, 00, 00);

                query = query.Where(a => a.RegisterDate >= registerDateFrom);
            }

            if (usersFilterViewModel.RegisterDateTo != null)
            {
                var persianCalendar = new PersianCalendar();

                var year = usersFilterViewModel.RegisterDateTo.Value.Year;
                var month = usersFilterViewModel.RegisterDateTo.Value.Month;
                var day = usersFilterViewModel.RegisterDateTo.Value.Day;

                var registerDateTo = persianCalendar.ToDateTime(year, month, day, 23, 59, 59, 59);

                query = query.Where(a => a.RegisterDate <= registerDateTo);
            }
        }
        catch
        {
        }

        #endregion

        usersFilterViewModel.Build(query.Count()).SetEntities(query);

        return usersFilterViewModel;
    }

    public async Task RemoveAsync(Guid id)
    {
        var user = await GetByIdAsync(id);

        if (user is null) return;

        user.IsDeleted = true;

        ApplicationDbContext.Users.Update(user);
    }

    public async Task DeleteAsync(Guid id)
    {
        var user = await GetByIdAsync(id);

        if (user is null) return;

        await DeleteAsync(user);
    }

    public async Task RestoreAsync(Guid id)
    {
        var user = await GetByIdAsync(id);

        if (user is null) return;

        user.IsDeleted = false;

        ApplicationDbContext.Users.Update(user);
    }

    public async Task ConfirmPhoneAsync(Guid id)
    {
        var user = await GetByIdAsync(id);

        if (user is null) return;

        user.PhoneNumberConfirmed = true;

        ApplicationDbContext.Users.Update(user);
    }

    public async Task UnConfirmPhoneAsync(Guid id)
    {
        var user = await GetByIdAsync(id);

        if (user is null) return;

        user.PhoneNumberConfirmed = false;

        ApplicationDbContext.Users.Update(user);
    }

    public async Task ConfirmEmailAsync(Guid id)
    {
        var user = await GetByIdAsync(id);

        if (user is null) return;

        user.EmailConfirmed = true;

        ApplicationDbContext.Users.Update(user);
    }

    public async Task UnConfirmEmailAsync(Guid id)
    {
        var user = await GetByIdAsync(id);

        if (user is null) return;

        user.EmailConfirmed = false;

        ApplicationDbContext.Users.Update(user);
    }

    public async Task<bool> LockAsync(Guid id, string lockoutReason, UserManager<ApplicationUser> userManager)
    {
        var user = await userManager.FindByIdAsync(id.ToString());

        if (user is null) return false;

        user.LockoutReason = lockoutReason;

        await userManager.SetLockoutEnabledAsync(user, true);

        var result = await userManager.SetLockoutEndDateAsync(user, DateTime.Now.AddYears(10));

        if (!result.Succeeded) return false;

        var updateResult = await userManager.UpdateAsync(user);

        return updateResult.Succeeded;
    }

    public async Task<bool> UnLockAsync(Guid id, UserManager<ApplicationUser> userManager)
    {
        var user = await userManager.FindByIdAsync(id.ToString());

        if (user is null) return false;

        user.LockoutReason = null;

        await userManager.SetLockoutEnabledAsync(user, false);

        var result = await userManager.SetLockoutEndDateAsync(user, null);

        if (!result.Succeeded) return false;

        var updateResult = await userManager.UpdateAsync(user);

        return updateResult.Succeeded;
    }

}