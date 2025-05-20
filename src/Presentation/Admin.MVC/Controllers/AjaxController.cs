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

        #region ( GetCityState )
        [HttpPost]
        public async Task<IActionResult> GetCityState(string city, string state, string neighbourhood)
        {
            if (string.IsNullOrWhiteSpace(city))
                return BadRequest();

            state = string.IsNullOrWhiteSpace(state) ? "البرز" : state;
            var stateBase = await UnitOfWork.StateBaseRepository.TableNoTracking.FirstOrDefaultAsync(a => a.Name.Contains(state));

            if (!string.IsNullOrWhiteSpace(neighbourhood))
            {
                neighbourhood = neighbourhood.Trim();
                var checkNeighbourhoodExist =
                    await UnitOfWork.CityBaseRepository.TableNoTracking.AnyAsync(a => a.Name.Equals(neighbourhood));
                if (checkNeighbourhoodExist)
                {
                    city = neighbourhood;
                }
            }

            var cityDetail = await UnitOfWork.CityBaseRepository.TableNoTracking.FirstOrDefaultAsync(a => a.Name.Equals(city) && a.StateId.Equals(stateBase.Id));

            return Json(new
            {
                city = cityDetail.Id,
                state = cityDetail.StateId
            });
        }
        #endregion

        #region ( Get Page Content )
        [HttpPost]
        public async Task<IActionResult> GetPageContent(int categoryId)
        {
            var category = await UnitOfWork.CategoryRepository.GetByPredicate(c => c.Id == categoryId);

            return Json(new
            {
                status = "success",
                contentPage = category.PageContent
            });
        }
        #endregion
    }
}
