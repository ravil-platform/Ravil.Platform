
using ViewModels.AdminPanel.Job;

namespace Admin.MVC.Controllers
{
    public class FaqsController(IUnitOfWork unitOfWork, IMapper mapper, IFtpService ftpService) : BaseController
    {
        #region ( DI )
        protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
        protected IMapper Mapper { get; } = mapper;
        protected IFtpService FtpService { get; } = ftpService;
        #endregion

        #region ( Faq )
        #region ( Index )
        public async Task<IActionResult> Index(FaqFilterViewModel filter)
        {
            var model = UnitOfWork.FaqRepository.GetByFilterAdmin(filter);

            #region ( Fill Faq Categories For Create Partial )
            var categories = await UnitOfWork.FaqCategoryRepository.GetAllAsync(f => f.ParentId == 0);

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
                #region ( Client Error )
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                ErrorAlert($"{Errors.ModelStateIsNotValidForm} - ارور : {errors[0]}");

                return RedirectToAction("Index");
                #endregion
            }

            #region ( Map )
            var faq = Mapper.Map<Faq>(createFaqViewModel);
            #endregion

            #region ( Sanitize Text )
            faq.Question = faq.Question.SanitizeText();
            #endregion

            #region ( Icon )

            var iconName = await FtpService.UploadFileToFtpServer(createFaqViewModel.File, TypeFile.Image, Paths.Faq, createFaqViewModel.File.FileName);

            faq.IconPicture = iconName;

            #endregion

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

            if (faq == null)
            {
                ErrorAlert("چیزی یافت نشد!");

                return RedirectToAction("Index");
            }

            faq = Mapper.Map(updateFaqViewModel, faq);

            #region ( Icon )
            if (updateFaqViewModel.File != null)
            {
                var deletedFile = "";

                if (faq.IconPicture != null)
                {
                    deletedFile = faq.IconPicture;
                }

                var pictureName = await FtpService.UploadFileToFtpServer(updateFaqViewModel.File, TypeFile.Image, Paths.Job, updateFaqViewModel.File.FileName, 777, null, null, null, deletedFile);

                faq.IconPicture = pictureName;
            }
            #endregion

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
