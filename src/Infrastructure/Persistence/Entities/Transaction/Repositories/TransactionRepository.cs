namespace Persistence.Entities.Transaction.Repositories;

public class TransactionRepository : Repository<Domain.Entities.Transaction.Transaction>, ITransactionRepository
{
    internal TransactionRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}