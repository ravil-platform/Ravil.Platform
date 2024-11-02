namespace Persistence.Entities.Job.Repositories.Implementations;

public class JobSelectionSliderRepository : Repository<JobSelectionSlider>, IJobSelectionSliderRepository
{
    internal JobSelectionSliderRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}