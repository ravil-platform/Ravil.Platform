namespace Persistence.Entities.Job.Repositories;

public class JobBranchGalleryRepository : Repository<JobBranchGallery>, IJobBranchGalleryRepository
{
    internal JobBranchGalleryRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}