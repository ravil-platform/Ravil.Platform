using ViewModels.Filter.Faq;

namespace Persistence.Entities.Faq.Repositories
{
    public interface IFaqCategoryRepository : IRepository<FaqCategory>
    {
        Task<ICollection<FaqCategory>> GetAllParents(CancellationToken cancellationToken);
        public FaqCategoryFilterViewModel GetByFilterAdmin(FaqCategoryFilterViewModel filter);
    }
}
