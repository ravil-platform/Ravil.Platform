using ViewModels.Filter.Faq;

namespace Admin.MVC.Controllers
{
    public class FaqsController : BaseController
    {
        #region ( DI )
        public IUnitOfWork UnitOfWork { get; }
        public IMapper Mapper { get; }
        public FaqsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
        #endregion

        #region ( Faq )
        #region ( Index )
        public async Task<IActionResult> Index(FaqFilterViewModel filter)
        {
            var model = UnitOfWork.FaqRepository.GetByFilterAdmin(filter);

            #region ( Fill Faq Categories For Create Partial )
            var categories = await UnitOfWork.FaqCategoryRepository.GetAllAsync(f=> f.ParentId == 0);

            if (categories.Count == 0)
            {
                categories = new List<FaqCategory>();
            }

            ViewData["faqCategories"] = categories;
            #endregion

            return View(model);
        }
        #endregion

        #region ( Create )
        [HttpPost]
        public async Task<IActionResult> Create(CreateFaqViewModel createFaqViewModel)
        {
            if (!ModelState.IsValid)
            {
                ErrorAlert(Errors.ModelStateIsNotValidForm);

                return RedirectToAction("Index");
            }

            var faq = Mapper.Map<Faq>(createFaqViewModel);
            faq.Question = faq.Question.SanitizeText();

            var iconName = Guid.NewGuid().ToString("N") + Path.GetExtension(createFaqViewModel.File.FileName);

            createFaqViewModel.File.AddImageToServer(iconName, Paths.FaqImageServer, TypeFile.Image);

            faq.IconPicture = iconName;

            await UnitOfWork.FaqRepository.InsertAsync(faq);

            try
            {
                await UnitOfWork.SaveAsync();

                SuccessAlert();
            }
            catch (Exception e)
            {
                ErrorAlert(e.Message);
            }

            return RedirectToAction("Index");
        }
        #endregion

        #region ( Update )
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var faq = await UnitOfWork.FaqRepository.GetByIdAsync(id);

            var model = Mapper.Map<UpdateFaqViewModel>(faq);

            #region ( Fill Faq Categories For Partial )
            var categories = await UnitOfWork.FaqCategoryRepository.GetAllAsync();
            var faqCategory = categories.First(c => c.Id == faq.CategoryId);

            if (categories.Count == 0)
            {
                categories = new List<FaqCategory>();
            }
            else
            {
                categories.Remove(faqCategory);
            }

            model.FaqCategories = new SelectList(categories, "Id", "Title");
            model.IconName = faq.IconPicture;
            model.CategoryName = faqCategory.Title;
            #endregion

            return PartialView("_Update", model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateFaqViewModel updateFaqViewModel)
        {
            var faq = await UnitOfWork.FaqRepository.GetByIdAsync(updateFaqViewModel.Id);
            faq = Mapper.Map(updateFaqViewModel, faq);

            var iconName = Guid.NewGuid().ToString("N") + Path.GetExtension(updateFaqViewModel.File.FileName);

            updateFaqViewModel.File.AddImageToServer(iconName, Paths.FaqImageServer, TypeFile.Image, null, null, null, faq.IconPicture);

            faq.IconPicture = iconName;
            faq.Question = faq.Question.SanitizeText();

            await UnitOfWork.FaqRepository.UpdateAsync(faq);


            try
            {
                await UnitOfWork.SaveAsync();

                SuccessAlert();
            }
            catch (Exception e)
            {
                ErrorAlert(e.Message);
            }

            return RedirectToAction("Index");
        }
        #endregion

        #region ( Detail )
        [HttpGet]
        public async Task<IActionResult> Detail(Guid id)
        {
            var model = await UnitOfWork.FaqRepository.GetByIdAsync(id);

            return View(model);
        }
        #endregion

        #region ( Delete )
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await UnitOfWork.FaqRepository.DeleteAsync(id);

            try
            {
                await UnitOfWork.SaveAsync();

                SuccessAlert();
            }
            catch (Exception ex)
            {
                ErrorAlert(ex.Message);
            }

            return RedirectToAction("Detail", new { Id = id });
        }
        #endregion
        #endregion

        #region ( Faq Categories )
        #region ( Index )
        public async Task<IActionResult> IndexFaqCategories(FaqCategoryFilterViewModel filter)
        {
            var model = UnitOfWork.FaqCategoryRepository.GetByFilterAdmin(filter);

            #region ( Fill Faq Categories For Create Partial )
            var categories = await UnitOfWork.FaqCategoryRepository.GetAllAsync();
            
            ViewData["faqCategories"] = categories;
            #endregion

            return View(model);
        }
        #endregion

        #region ( Create )
        [HttpPost]
        public async Task<IActionResult> CreateFaqCategories(CreateFaqCategoryViewModel createFaqCategoryViewModel)
        {
            if (!ModelState.IsValid)
            {
                ErrorAlert(Errors.ModelStateIsNotValidForm);

                return RedirectToAction("IndexFaqCategories");
            }

            var faqCategory = Mapper.Map<FaqCategory>(createFaqCategoryViewModel);

            await UnitOfWork.FaqCategoryRepository.InsertAsync(faqCategory);

            try
            {
                await UnitOfWork.SaveAsync();

                SuccessAlert();
            }
            catch (Exception e)
            {
                ErrorAlert(e.Message);
            }

            return RedirectToAction("IndexFaqCategories");
        }
        #endregion

        #region ( Update )
        [HttpGet]
        public async Task<IActionResult> UpdateFaqCategories(int id)
        {
            var faqCategories = await UnitOfWork.FaqCategoryRepository.GetByIdAsync(id);

            var model = Mapper.Map<UpdateFaqCategoryViewModel>(faqCategories);

            #region ( Fill Faq Categories For Partial )
            var categories = await
                UnitOfWork.FaqCategoryRepository.GetAllAsync();

            var currentFaqCategory = categories.First(c => c.Id == faqCategories.Id);

            #region ( Remove Curren Category From List )
            if (categories.Count == 0)
            {
                categories = new List<FaqCategory>();
            }
            else
            {
                categories.Remove(currentFaqCategory);
            }
            #endregion

            #region ( Fill Parent Name If Exist )
            if (faqCategories.ParentId != 0)
            {
                var parent = await UnitOfWork.FaqCategoryRepository.GetByIdAsync(faqCategories.ParentId);

                model.ParentName = parent.Title;
            }
            #endregion

            model.FaqCategories = new SelectList(categories, "Id", "Title");
            #endregion

            return PartialView("_UpdateFaqCategories", model);
        }

        #endregion

        #endregion
    }
}
