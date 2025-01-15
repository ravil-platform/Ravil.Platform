using Microsoft.EntityFrameworkCore;

namespace Admin.MVC.Controllers
{
    public class AjaxController : Controller
    {
        #region ( DI )
        protected IUnitOfWork UnitOfWork { get; }
        public AjaxController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        #endregion

        #region (Get Cities By State Base Id)
        [HttpPost]
        public async Task<IActionResult> GetCities(int stateBaseId)
        {
            var cities = await UnitOfWork.CityRepository.TableNoTracking
                .Include(c => c.CityBase).Where(c => c.CityBase.StateId == stateBaseId)
                .Select(c => new { title = c.Subtitle, id = c.CityBaseId }).ToListAsync();

            return Json(new
            {
                status = "success",
                cities
            });
        }
        #endregion

        #region ( Get Faq Child Categories )
        [HttpPost]
        public async Task<IActionResult> GetChildFaqCategories(int parentId)
        {
            var faqChild = await UnitOfWork.FaqCategoryRepository.TableNoTracking.Where(f => f.ParentId == parentId)
                .Select(c => new { title = c.Title, id = c.Id }).ToListAsync();

            return Json(new
            {
                status = "success",
                faqChild = faqChild
            });
        }
        #endregion

        #region ( Get Faq By CategoryId )
        [HttpPost]
        public async Task<IActionResult> GetFaqsByCategoryId(int categoryId)
        {
            var faqs = await UnitOfWork.FaqRepository.TableNoTracking.Where(f => f.CategoryId == categoryId)
                .Select(c => new { question = c.Question, id = c.Id }).ToListAsync();

            return Json(new
            {
                status = "success",
                faqs = faqs
            });
        }
        #endregion
    }
}
