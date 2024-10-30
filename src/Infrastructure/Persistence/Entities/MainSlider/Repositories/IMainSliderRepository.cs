namespace Persistence.Entities.MainSlider.Repositories
{
    public interface IMainSliderRepository : IRepository<Domain.Entities.MainSlider.MainSlider>
    {
        Task<List<Domain.Entities.MainSlider.MainSlider>> GetAllByJobBranchId(string jobBranchId, int take);
        Task<List<Domain.Entities.MainSlider.MainSlider>> GetAllByStateId(int stateId, int take);
        Task<List<Domain.Entities.MainSlider.MainSlider>> GetAllByCityId(int cityId, int take);
    }
}