namespace Persistence.Entities.Job.Repositories.Implementations;

public class JobBranchGalleryRepository : Repository<JobBranchGallery>, IJobBranchGalleryRepository
{
    internal JobBranchGalleryRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}