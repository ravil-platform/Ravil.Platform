using ViewModels.AdminPanel.Filter;

namespace Persistence.Entities.State.Repositories;

public interface IStateBaseRepository : IRepository<StateBase>
{
    StateBaseFilterViewModel GetByFilterAdmin(StateBaseFilterViewModel filter);
}