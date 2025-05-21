namespace Admin.MVC.Controllers
{
    public class FeedbackSliderController(IMapper mapper, IUnitOfWork unitOfWork, IFtpService ftpService)
        : BaseController
    {
        #region ( DI )
        protected IMapper Mapper { get; } = mapper;
        protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
        protected IFtpService FtpService { get; } = ftpService;

        #endregion

        #region ( Index )
        public async Task<IActionResult> Index(FeedbackSliderFilterViewModel filter)
        {
            ViewData["categories"] = await UnitOfWork.CategoryRepository.GetAllAsync(c => c.NodeLevel == 3);

            return View(UnitOfWork.FeedbackSliderRepository.GetByFilterAdmin(filter));
        }
        #endregion

        #region ( Create )
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["categories"] = await UnitOfWork.CategoryRepository.GetAllAsync(c => c.NodeLevel == 3);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFeedbackSliderViewModel createFeedbackSliderViewModel)
        {
            if (!ModelState.IsValid)
            {
                #region ( Client Side Error )
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                ErrorAlert($"{Errors.ModelStateIsNotValidForm} - ارور : {errors[0]}");

                ViewData["categories"] = await UnitOfWork.CategoryRepository.GetAllAsync(c => c.NodeLevel == 3);

                return View();
                #endregion
            }

            var feedbackSlider = Mapper.Map<FeedbackSlider>(createFeedbackSliderViewModel);

            var pictureName = await FtpService.UploadFileToFtpServer(createFeedbackSliderViewModel.PictureFile, TypeFile.Image, Paths.FeedbackSlider, createFeedbackSliderViewModel.PictureFile.FileName);

            feedbackSlider.Picture = pictureName;
            feedbackSlider.Description = feedbackSlider.Description.SanitizeText();

            await UnitOfWork.FeedbackSliderRepository.InsertAsync(feedbackSlider);

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
            var currentFeedbackSlider = await UnitOfWork.FeedbackSliderRepository.GetByIdAsync(id);

            if (currentFeedbackSlider == null)
            {
                ErrorAlert("چیزی یافت نشد!");

                return RedirectToAction("Index");
            }

            var model = Mapper.Map<UpdateFeedbackSliderViewModel>(currentFeedbackSlider);

            ViewData["categories"] = await UnitOfWork.CategoryRepository.GetAllAsync(c => c.NodeLevel == 3);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateFeedbackSliderViewModel updateFeedbackSliderViewModel)
        {
            if (!ModelState.IsValid)
            {
                #region ( Feedback Slider )
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                ErrorAlert($"{Errors.ModelStateIsNotValidForm} - ارور : {errors[0]}");

                ViewData["categories"] = await UnitOfWork.CategoryRepository.GetAllAsync(c => c.NodeLevel == 3);

                return View();
                #endregion
            }

            var feedbackSlider = await UnitOfWork.FeedbackSliderRepository.GetByIdAsync(updateFeedbackSliderViewModel.Id);

            feedbackSlider = Mapper.Map(updateFeedbackSliderViewModel, feedbackSlider);

            #region ( FeedbackSlider is null )
            if (feedbackSlider == null)
            {
                ErrorAlert();

                return RedirectToAction("Index");
            }
            #endregion

            #region ( Picture )
            if (updateFeedbackSliderViewModel.PictureFile != null)
            {
                var deletedFile = "";

                if (feedbackSlider.Picture != null)
                {
                    deletedFile = feedbackSlider.Picture;
                }

                var pictureName = await FtpService.UploadFileToFtpServer(updateFeedbackSliderViewModel.PictureFile, TypeFile.Image, Paths.FeedbackSlider, updateFeedbackSliderViewModel.PictureFile.FileName, 777, null, null, null, deletedFile);

                feedbackSlider.Picture = pictureName;
            }
            #endregion

            await UnitOfWork.FeedbackSliderRepository.UpdateAsync(feedbackSlider!);

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

        #region ( Delete )
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var feedbackSlider = await UnitOfWork.FeedbackSliderRepository.GetByIdAsync(id);

            if (feedbackSlider == null)
            {
                ErrorAlert("چیزی یافت نشد!");

                return RedirectToAction("Index");
            }

            try
            {
                await UnitOfWork.FeedbackSliderRepository.DeleteAsync(feedbackSlider);
                await UnitOfWork.SaveAsync();
            }
            catch (Exception exception)
            {
                ErrorAlert(exception.Message);
            }

            return RedirectToAction("Index");
        }
        #endregion
    }
}
