using Common.Utilities.Services.FTP;
using Domain.Entities.Banner;
using Enums;
using ViewModels.AdminPanel.Banner;
using ViewModels.AdminPanel.Filter;

namespace Admin.MVC.Controllers
{
    public class BannerController : BaseController
    {
        #region ( DI )
        protected IMapper Mapper { get; }
        protected IUnitOfWork UnitOfWork { get; }
        protected IFtpService FtpService { get; }
        public BannerController(IMapper mapper, IUnitOfWork unitOfWork, IFtpService ftpService)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            FtpService = ftpService;
        }
        #endregion

        #region ( Index )
        public IActionResult Index(BannerFilterViewModel filter)
        {
            return View(UnitOfWork.BannerRepository.GetByFilter(filter));
        }
        #endregion

        #region ( Create )
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["jobBranches"] = await UnitOfWork.JobBranchRepository.GetAllAsync(j => j.Status == JobBranchStatus.Accepted && j.IsDeleted == false);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBannerViewModel createBannerViewModel)
        {
            if (!ModelState.IsValid)
            {
                #region ( Client Error )
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                ErrorAlert($"{Errors.ModelStateIsNotValidForm} - ارور : {errors[0]}");
                #endregion

                ViewData["jobBranches"] = await UnitOfWork.JobBranchRepository.GetAllAsync(j => j.Status == JobBranchStatus.Accepted && j.IsDeleted == false);

                return View(createBannerViewModel);
            }

            var banner = Mapper.Map<Banner>(createBannerViewModel);

            var pictureName = await FtpService.UploadFileToFtpServer(createBannerViewModel.LargePictureFile, TypeFile.Image, Paths.Banner, createBannerViewModel.LargePictureFile.FileName);
            var mobilePictureName = await FtpService.UploadFileToFtpServer(createBannerViewModel.SmallPictureFile, TypeFile.Image, Paths.Banner, createBannerViewModel.SmallPictureFile.FileName);

            banner.LargePicture = pictureName;
            banner.SmallPicture = mobilePictureName;
            banner.CreateDate = DateTime.Now;
            banner.ExpireDate = new DateTime(2045,1,1);

            await UnitOfWork.BannerRepository.InsertAsync(banner);

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
            var currentBanner = await UnitOfWork.BannerRepository.GetByIdAsync(id);

            var model = Mapper.Map<UpdateBannerViewModel>(currentBanner);

            model.CurrentLargePicture = currentBanner.LargePicture;
            model.CurrentSmallPicture = currentBanner.SmallPicture;

            ViewData["jobBranches"] = await UnitOfWork.JobBranchRepository.GetAllAsync(j => j.Status == JobBranchStatus.Accepted && j.IsDeleted == false);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateBannerViewModel updateBannerViewModel)
        {
            if (!ModelState.IsValid)
            {
                #region ( Client Error )
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                ErrorAlert($"{Errors.ModelStateIsNotValidForm} - ارور : {errors[0]}");
                #endregion

                ViewData["jobBranches"] = await UnitOfWork.JobBranchRepository.GetAllAsync(j => j.Status == JobBranchStatus.Accepted && j.IsDeleted == false);

                return View(updateBannerViewModel);
            }

            var Banner = await UnitOfWork.BannerRepository.GetByIdAsync(updateBannerViewModel.Id);

            Banner = Mapper.Map(updateBannerViewModel, Banner);

            #region ( Banner is null )
            if (Banner == null)
            {
                ErrorAlert();

                return RedirectToAction("Index");
            }
            #endregion

            #region ( Picture )
            #region ( Descktop )
            if (updateBannerViewModel.LargePictureFile != null)
            {
                var deletedFile = "";

                if (Banner.LargePicture != null)
                {
                    deletedFile = Banner.LargePicture;
                }

                var pictureName = await FtpService.UploadFileToFtpServer(updateBannerViewModel.LargePictureFile, TypeFile.Image, Paths.Banner, updateBannerViewModel.LargePictureFile.FileName, 777, null, null, null, deletedFile);

                Banner.LargePicture = pictureName;
            }
            #endregion

            #region ( Mobile )
            if (updateBannerViewModel.SmallPictureFile != null)
            {
                var deletedFile = "";

                if (Banner.SmallPicture != null)
                {
                    deletedFile = Banner.SmallPicture;
                }

                var mobilePictureName = await FtpService.UploadFileToFtpServer(updateBannerViewModel.SmallPictureFile, TypeFile.Image, Paths.Banner, updateBannerViewModel.SmallPictureFile.FileName, 777, null, null, null, deletedFile);

                Banner.SmallPicture = mobilePictureName;
            }
            #endregion
            #endregion

            Banner.LastUpdateDate = DateTime.Now;

            await UnitOfWork.BannerRepository.UpdateAsync(Banner!);

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
