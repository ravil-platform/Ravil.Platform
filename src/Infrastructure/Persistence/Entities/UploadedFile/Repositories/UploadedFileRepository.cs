namespace Persistence.Entities.UploadedFile.Repositories;

public class UploadedFileRepository : Repository<Domain.Entities.UploadedFile.UploadedFile>, IUploadedFileRepository
{
    internal UploadedFileRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}