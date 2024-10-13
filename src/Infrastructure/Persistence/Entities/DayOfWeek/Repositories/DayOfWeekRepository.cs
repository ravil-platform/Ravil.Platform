namespace Persistence.Entities.DayOfWeek.Repositories;

public class DayOfWeekRepository : Repository<Domain.Entities.DayOfWeek.DayOfWeek>, IDayOfWeekRepository
{
    internal DayOfWeekRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}