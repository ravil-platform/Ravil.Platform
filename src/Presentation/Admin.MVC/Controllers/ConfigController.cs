namespace Admin.MVC.Controllers
{
    public class ConfigController(IUnitOfWork unitOfWork, IMapper mapper) : BaseController
    {
        #region ( DI )
        protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
        protected IMapper Mapper { get; } = mapper;

        #endregion

        #region ( Config Crud )
        [HttpGet]
        public async Task<IActionResult> IndexConfig()
        {
            var config = await UnitOfWork.ConfigRepository.GetFirstAsync();
            var model = Mapper.Map<AdminConfigViewModel>(config);

            ViewData["states"] = await UnitOfWork.StateBaseRepository.GetAllAsync();
            ViewData["cities"] = await UnitOfWork.CityBaseRepository.GetAllAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> IndexConfig(AdminConfigViewModel config)
        {
            try
            {
                var currentConfig = await UnitOfWork.ConfigRepository.GetFirstAsync();
                var model = Mapper.Map(config, currentConfig);

                await UnitOfWork.ConfigRepository.UpdateAsync(model);
                await UnitOfWork.SaveAsync();

                SuccessAlert();
            }
            catch
            {
                ErrorAlert();
            }

            return RedirectToAction("IndexConfig");
        }

        [HttpGet]
        public async Task<IActionResult> IndexConfigPageInformation()
        {
            var config = await UnitOfWork.ConfigRepository.GetFirstAsync();
            var model = Mapper.Map<AdminConfigViewModel>(config);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> IndexConfigPageInformation(AdminConfigViewModel config)
        {
            try
            {
                var currentConfig = await UnitOfWork.ConfigRepository.GetFirstAsync();
                var model = Mapper.Map(config, currentConfig);

                #region ( Files )
                //#region ( Home Page )
                //if (config.AboutUsVideoFile != null)
                //{
                //    string? deletedFile = null;

                //    if (currentConfig.AboutUsVideo != null)
                //    {
                //        deletedFile = currentConfig.AboutUsVideo;
                //    }

                //    var file = await FtpService.UploadFileToFtpServer(config.AboutUsVideoFile, TypeFile.Image,
                //        config.AboutUsVideoFile.FileName, Paths.HomePageImage, 777, null, null, null, deletedFile);
                //    //var file = config.HomePictureFile
                //    //    .SaveFileAndReturnName(Paths.HomePageImage, config.HomePictureFile.FileName, TypeFile.Image, null, null, null, deletedFile);
                //    model.HomePicture = file;
                //}

                //if (config.HomeMobilePictureFile != null)
                //{
                //    string? deletedFile = null;

                //    if (currentConfig.HomeMobilePicture != null)
                //    {
                //        deletedFile = currentConfig.HomeMobilePicture;
                //    }

                //    var file = await FtpService.UploadFileToFtpServer(config.HomeMobilePictureFile, TypeFile.Image,
                //        config.HomeMobilePictureFile.FileName, Paths.HomePageImage, 777, null, null, null, deletedFile);
                //    //var file = config.HomeMobilePictureFile
                //    //    .SaveFileAndReturnName(Paths.HomePageImage, config.HomeMobilePictureFile.FileName, TypeFile.Image, null, null, null, deletedFile);
                //    model.HomeMobilePicture = file;
                //}
                //#endregion

                //#region ( About )
                //if (config.AboutUsPictureFile != null)
                //{
                //    string? deletedFile = null;

                //    if (currentConfig.AboutUsPicture != null)
                //    {
                //        deletedFile = currentConfig.AboutUsPicture;
                //    }

                //    var file = await FtpService.UploadFileToFtpServer(config.AboutUsPictureFile, TypeFile.Image,
                //        config.AboutUsPictureFile.FileName, Paths.AboutPageImage, 777, null, null, null, deletedFile);
                //    //var file = config.AboutUsPictureFile
                //    //    .SaveFileAndReturnName(Paths.AboutPageImagePath, config.AboutUsPictureFile.FileName, TypeFile.Image, null, null, null, deletedFile);
                //    model.AboutUsPicture = file;
                //}

                //if (config.AboutUsMobilePictureFile != null)
                //{
                //    string? deletedFile = null;

                //    if (currentConfig.AboutUsMobilePicture != null)
                //    {
                //        deletedFile = currentConfig.AboutUsMobilePicture;
                //    }
                //    var file = await FtpService.UploadFileToFtpServer(config.AboutUsMobilePictureFile, TypeFile.Image,
                //        config.AboutUsMobilePictureFile.FileName, Paths.AboutPageImage, 777, null, null, null, deletedFile);
                //    //var file = config.AboutUsMobilePictureFile
                //    //    .SaveFileAndReturnName(Paths.AboutPageImagePath, config.AboutUsMobilePictureFile.FileName, TypeFile.Image, null, null, null, deletedFile);
                //    model.AboutUsMobilePicture = file;
                //}

                //if (config.AboutUsMissionBoxPictureFile != null)
                //{
                //    string? deletedFile = null;

                //    if (currentConfig.AboutUsMissionBoxPicture != null)
                //    {
                //        deletedFile = currentConfig.AboutUsMissionBoxPicture;
                //    }
                //    var file = await FtpService.UploadFileToFtpServer(config.AboutUsMissionBoxPictureFile, TypeFile.Image,
                //        config.AboutUsMissionBoxPictureFile.FileName, Paths.AboutPageImage, 777, null, null, null, deletedFile);
                //    //var file = config.AboutUsMissionBoxPictureFile
                //    //    .SaveFileAndReturnName(Paths.AboutPageImagePath, config.AboutUsMissionBoxPictureFile.FileName, TypeFile.Image, null, null, null, deletedFile);
                //    model.AboutUsMissionBoxPicture = file;
                //}

                //if (config.AboutUsMissionBoxMobilePictureFile != null)
                //{
                //    string? deletedFile = null;

                //    if (currentConfig.AboutUsMissionBoxMobilePicture != null)
                //    {
                //        deletedFile = currentConfig.AboutUsMissionBoxMobilePicture;
                //    }
                //    var file = await FtpService.UploadFileToFtpServer(config.AboutUsMissionBoxMobilePictureFile, TypeFile.Image,
                //        config.AboutUsMissionBoxMobilePictureFile.FileName, Paths.AboutPageImage, 777, null, null, null, deletedFile);
                //    //var file = config.AboutUsMissionBoxMobilePictureFile
                //    //    .SaveFileAndReturnName(Paths.AboutPageImagePath, config.AboutUsMissionBoxMobilePictureFile.FileName, TypeFile.Image, null, null, null, deletedFile);
                //    model.AboutUsMissionBoxMobilePicture = file;
                //}

                //if (config.AboutUsVideoFile != null)
                //{
                //    string? deletedFile = null;

                //    if (currentConfig.AboutUsVideo != null)
                //    {
                //        deletedFile = currentConfig.AboutUsVideo;
                //    }
                //    var file = await FtpService.UploadFileToFtpServer(config.AboutUsVideoFile, TypeFile.Video,
                //        config.AboutUsVideoFile.FileName, Paths.AboutPageVideo, 777, null, null, null, deletedFile);
                //    //var file = config.AboutUsVideoFile
                //    //    .SaveFileAndReturnName(Paths.AboutPageVideoPath, config.AboutUsVideoFile.FileName, TypeFile.Video, null, null, null, deletedFile);

                //    model.AboutUsVideo = file;
                //}
                //#endregion

                //#region ( Introduction )
                //if (config.IntroductionVideoFile != null)
                //{
                //    string? deletedFile = null;

                //    if (currentConfig.IntroductionVideo != null)
                //    {
                //        deletedFile = currentConfig.IntroductionVideo;
                //    }
                //    var file = await FtpService.UploadFileToFtpServer(config.IntroductionVideoFile, TypeFile.Video,
                //        config.IntroductionVideoFile.FileName, Paths.AboutPageVideo, 777, null, null, null, deletedFile);
                //    //var file = config.IntroductionVideoFile
                //    //    .SaveFileAndReturnName(Paths.HomePageIntroductionVideo, config.IntroductionVideoFile.FileName, TypeFile.Video, null, null, null, deletedFile);
                //    model.IntroductionVideo = file;
                //}

                //if (config.IntroductionVideoCoverFile != null)
                //{
                //    string? deletedFile = null;

                //    if (currentConfig.IntroductionVideoCover != null)
                //    {
                //        deletedFile = currentConfig.IntroductionVideoCover;
                //    }
                //    var file = await FtpService.UploadFileToFtpServer(config.IntroductionVideoCoverFile, TypeFile.Image,
                //        config.IntroductionVideoCoverFile.FileName, Paths.HomePageIntroductionImage, 777, null, null, null, deletedFile);
                //    //var file = config.IntroductionVideoCoverFile
                //    //    .SaveFileAndReturnName(Paths.HomePageIntroductionImage, config.IntroductionVideoCoverFile.FileName, TypeFile.Image, null, null, null, deletedFile);
                //    model.IntroductionVideoCover = file;
                //}

                //if (config.IntroductionMobileVideoCoverFile != null)
                //{
                //    string? deletedFile = null;

                //    if (currentConfig.IntroductionMobileVideoCover != null)
                //    {
                //        deletedFile = currentConfig.IntroductionMobileVideoCover;
                //    }
                //    var file = await FtpService.UploadFileToFtpServer(config.IntroductionMobileVideoCoverFile, TypeFile.Image,
                //        config.IntroductionMobileVideoCoverFile.FileName, Paths.HomePageIntroductionImage, 777, null, null, null, deletedFile);
                //    //var file = config.IntroductionMobileVideoCoverFile
                //    //    .SaveFileAndReturnName(Paths.HomePageIntroductionImage, config.IntroductionMobileVideoCoverFile.FileName, TypeFile.Image, null, null, null, deletedFile);
                //    model.IntroductionMobileVideoCover = file;
                //}
                //#endregion
                #endregion

                await UnitOfWork.ConfigRepository.UpdateAsync(model);
                await UnitOfWork.SaveAsync();

                SuccessAlert();
            }
            catch
            {

            }

            return RedirectToAction("IndexConfigPageInformation");
        }
        #endregion
    }
}
