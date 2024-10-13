namespace Persistence.Entities.Job.Repositories;

public class JobSelectionSliderRepository : Repository<JobSelectionSlider>, IJobSelectionSliderRepository
{
    internal JobSelectionSliderRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}