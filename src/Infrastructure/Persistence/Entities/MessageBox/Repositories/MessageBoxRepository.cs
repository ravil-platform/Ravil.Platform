namespace Persistence.Entities.MessageBox.Repositories;

public class MessageBoxRepository : Repository<Domain.Entities.MessageBox.MessageBox>, IMessageBoxRepository
{
    protected ApplicationDbContext ApplicationDbContext { get; }
    internal MessageBoxRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }
}