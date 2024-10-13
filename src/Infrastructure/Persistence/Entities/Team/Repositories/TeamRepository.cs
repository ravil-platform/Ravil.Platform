namespace Persistence.Entities.Team.Repositories;

public class TeamRepository : Repository<Domain.Entities.Team.Team>, ITeamRepository
{
    internal TeamRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}