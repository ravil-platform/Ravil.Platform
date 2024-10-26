using Persistence.Entities.Job.Repositories.Interfaces;

namespace Persistence.Entities.Job.Repositories.Implementations;

public class JobSelectionSliderRepository : Repository<JobSelectionSlider>, IJobSelectionSliderRepository
{
    internal JobSelectionSliderRepository(DbContext databaseContext) : base(databaseContext)
    {
    }
}