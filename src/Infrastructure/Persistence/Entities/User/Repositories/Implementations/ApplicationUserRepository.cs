using Common.Utilities.Extensions;

namespace Persistence.Entities.User.Repositories;

public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
{
    public ApplicationDbContext ApplicationDbContext { get; }
    internal ApplicationUserRepository(ApplicationDbContext databaseContext) : base(databaseContext)
    {
        ApplicationDbContext = databaseContext;
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



        //try
        //{
        //    if (UserFilterViewModel.RegisterDateFrom != null)
        //    {
        //        PersianCalendar PersianCalendar = new PersianCalendar();

        //        int Year = UserFilterViewModel.RegisterDateFrom.Value.Year;
        //        int Month = UserFilterViewModel.RegisterDateFrom.Value.Month;
        //        int Day = UserFilterViewModel.RegisterDateFrom.Value.Day;

        //        DateTime RegisterDateFrom = PersianCalendar.ToDateTime(Year, Month, Day, 00, 00, 00, 00);

        //        query = query.Where(U => U.CreatedDate >= RegisterDateFrom);
        //    }

        //    if (UserFilterViewModel.RegisterDateTo != null)
        //    {
        //        PersianCalendar PersianCalendar = new PersianCalendar();

        //        int Year = UserFilterViewModel.RegisterDateTo.Value.Year;
        //        int Month = UserFilterViewModel.RegisterDateTo.Value.Month;
        //        int Day = UserFilterViewModel.RegisterDateTo.Value.Day;

        //        DateTime RegisterDateTo = PersianCalendar.ToDateTime(Year, Month, Day, 23, 59, 59, 59);

        //        query = query.Where(U => U.CreatedDate <= RegisterDateTo);
        //    }
        //}
        //catch { }
        #endregion

        usersFilterViewModel.Build(query.Count()).SetEntities(query);

        return usersFilterViewModel;
    }

    public override Task InsertAsync(ApplicationUser entity)
    {
        entity.PasswordHash = Security.GetSha256Hash(entity.PasswordHash!);
        entity.PhoneNumberConfirmed = true;

        return base.InsertAsync(entity);
    }
}