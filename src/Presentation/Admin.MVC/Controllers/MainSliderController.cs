namespace Admin.MVC.Controllers
{
    public class MainSliderController(IMapper mapper, IUnitOfWork unitOfWork, IFtpService ftpService)
        : BaseController
    {
        #region ( DI )
        protected IMapper Mapper { get; } = mapper;
        protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
        protected IFtpService FtpService { get; } = ftpService;

        #endregion

        #region ( Index )
        public async Task<IActionResult> Index(MainSliderFilterViewModel filter)
        {
            ViewData["stateBases"] = await UnitOfWork.StateBaseRepository.GetAllAsync();
            ViewData["cities"] = await UnitOfWork.CityRepository.GetAllAsync();

            return View(UnitOfWork.MainSliderRepository.GetByFilterAdmin(filter));
        }
        #endregion

        #region ( Create )
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["stateBases"] = await UnitOfWork.StateBaseRepository.GetAllAsync();
            ViewData["jobBranches"] = await UnitOfWork.JobBranchRepository.GetAllAsync(j => j.Status == JobBranchStatus.Accepted && j.IsDeleted == false);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMainSliderViewModel createMainSliderViewModel)
        {
            if (!ModelState.IsValid)
            {
                #region ( Client Error )
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                ErrorAlert($"{Errors.ModelStateIsNotValidForm} - ارور : {errors[0]}");
                #endregion

                ViewData["stateBases"] = await UnitOfWork.StateBaseRepository.GetAllAsync();
                ViewData["jobBranches"] = await UnitOfWork.JobBranchRepository.GetAllAsync(j => j.Status == JobBranchStatus.Accepted && j.IsDeleted == false);

                return View(createMainSliderViewModel);
            }

            var mainSlider = Mapper.Map<MainSlider>(createMainSliderViewModel);

            var pictureName = await FtpService.UploadFileToFtpServer(createMainSliderViewModel.LargePictureFile, TypeFile.Image, Paths.MainSlider, createMainSliderViewModel.LargePictureFile.FileName);
            var mobilePictureName = await FtpService.UploadFileToFtpServer(createMainSliderViewModel.SmallPictureFile, TypeFile.Image, Paths.MainSlider, createMainSliderViewModel.SmallPictureFile.FileName);

            mainSlider.ExpireDay = createMainSliderViewModel.ExpireDay ?? 9999;

            mainSlider.LargePicture = pictureName;
            mainSlider.SmallPicture = mobilePictureName;
            mainSlider.CreateDate = DateTime.Now;

            await UnitOfWork.MainSliderRepository.InsertAsync(mainSlider);

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
            var currentMainSlider = await UnitOfWork.MainSliderRepository.GetByIdAsync(id);

            var model = Mapper.Map<UpdateMainSliderViewModel>(currentMainSlider);

            model.CurrentLargePicture = currentMainSlider.LargePicture;
            model.CurrentSmallPicture = currentMainSlider.SmallPicture;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateMainSliderViewModel updateMainSliderViewModel)
        {
            if (!ModelState.IsValid)
            {
                #region ( Client Error )
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                ErrorAlert($"{Errors.ModelStateIsNotValidForm} - ارور : {errors[0]}");
                #endregion

                return View(updateMainSliderViewModel);
            }

            var mainSlider = await UnitOfWork.MainSliderRepository.GetByIdAsync(updateMainSliderViewModel.Id);

            mainSlider = Mapper.Map(updateMainSliderViewModel, mainSlider);

            #region ( MainSlider is null )
            if (mainSlider == null)
            {
                ErrorAlert();

                return RedirectToAction("Index");
            }
            #endregion

            #region ( Picture )
            #region ( Descktop )
            if (updateMainSliderViewModel.LargePictureFile != null)
            {
                var deletedFile = "";

                if (mainSlider.LargePicture != null)
                {
                    deletedFile = mainSlider.LargePicture;
                }

                var pictureName = await FtpService.UploadFileToFtpServer(updateMainSliderViewModel.LargePictureFile, TypeFile.Image, Paths.MainSlider, updateMainSliderViewModel.LargePictureFile.FileName, 777, null, null, null, deletedFile);

                mainSlider.LargePicture = pictureName;
            }
            #endregion

            #region ( Mobile )
            if (updateMainSliderViewModel.SmallPictureFile != null)
            {
                var deletedFile = "";

                if (mainSlider.SmallPicture != null)
                {
                    deletedFile = mainSlider.SmallPicture;
                }

                var mobilePictureName = await FtpService.UploadFileToFtpServer(updateMainSliderViewModel.SmallPictureFile, TypeFile.Image, Paths.MainSlider, updateMainSliderViewModel.SmallPictureFile.FileName, 777, null, null, null, deletedFile);

                mainSlider.SmallPicture = mobilePictureName;
            }
            #endregion
            #endregion

            mainSlider.LastUpdateDate = DateTime.Now;

            await UnitOfWork.MainSliderRepository.UpdateAsync(mainSlider!);

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
    }
}
