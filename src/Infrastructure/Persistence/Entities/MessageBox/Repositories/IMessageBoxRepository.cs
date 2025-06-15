using ViewModels.AdminPanel.Filter;

namespace Persistence.Entities.MessageBox.Repositories;

public interface IMessageBoxRepository : IRepository<Domain.Entities.MessageBox.MessageBox>
{
    MessageBoxFilterViewModel GetByFilter(MessageBoxFilterViewModel filter);

    Task<bool> SendMessage(int jobId, MessageBoxType type, string description);
}