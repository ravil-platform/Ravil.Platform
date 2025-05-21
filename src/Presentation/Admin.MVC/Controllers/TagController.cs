namespace Admin.MVC.Controllers
{
    public class TagController(IMapper mapper, IUnitOfWork unitOfWork, IFtpService ftpService)
        : BaseController
    {
        #region ( DI )
        protected IMapper Mapper { get; } = mapper;
        protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
        protected IFtpService FtpService { get; } = ftpService;

        #endregion

        #region ( Tags )
        #region ( Index )
        public IActionResult Index(TagsFilterViewModel filter)
        {
            return View(UnitOfWork.TagRepository.GetByFilter(filter));
        }
        #endregion

        #region ( Create )
        [HttpPost]
        public async Task<IActionResult> Create(CreateTagViewModel createTagViewModel)
        {
            if (!ModelState.IsValid)
            {
                ErrorAlert(Errors.ModelStateIsNotValidForm);

                return RedirectToAction("Index");
            }

            var tag = Mapper.Map<Tag>(createTagViewModel);

            var iconName = await FtpService.UploadFileToFtpServer(createTagViewModel.IconPictureFile, TypeFile.Image, Paths.Tag, createTagViewModel.IconPictureFile.FileName);

            tag.IconPicture = iconName;

            await UnitOfWork.TagRepository.InsertAsync(tag);

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
        public async Task<IActionResult> Update(int tagId)
        {
            var currentTags = await UnitOfWork.TagRepository.GetByIdAsync(tagId);

            if (currentTags == null)
            {
                ErrorAlert("تگ یافت نشد!");

                return RedirectToAction("Index");
            }

            var model = Mapper.Map<UpdateTagViewModel>(currentTags);
            model.CurrentIconPicture = currentTags.IconPicture;

            return PartialView("_Update", model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateTagViewModel updateTagViewModel)
        {
            if (!ModelState.IsValid)
            {
                ErrorAlert(Errors.ModelStateIsNotValidForm);

                return RedirectToAction("Index");
            }

            var tag = await UnitOfWork.TagRepository.GetByIdAsync(updateTagViewModel.Id);

            tag = Mapper.Map(updateTagViewModel, tag);

            #region ( Picture )
            if (updateTagViewModel.IconPictureFile != null)
            {
                var deletedFile = "";

                if (tag.IconPicture != null)
                {
                    deletedFile = tag.IconPicture;
                }

                var iconName = await FtpService.UploadFileToFtpServer(updateTagViewModel.IconPictureFile, TypeFile.Image, Paths.Tag, updateTagViewModel.IconPictureFile.FileName, 777, null, null, null, deletedFile);

                tag.IconPicture = iconName;
            }
            #endregion

            await UnitOfWork.TagRepository.UpdateAsync(tag!);

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

        #region ( Set Activation )
        [HttpGet]
        public async Task<IActionResult> SetActivationTag(int id, bool active)
        {
            var tag = await UnitOfWork.TagRepository.GetByIdAsync(id);

            tag.Status = active;

            try
            {
                await UnitOfWork.TagRepository.UpdateAsync(tag);
                await UnitOfWork.SaveAsync();

                SuccessAlert();
            }
            catch (Exception ex)
            {
                ErrorAlert(ex.Message);
            }

            return RedirectToAction("Index");
        }
        #endregion
        #endregion
    }
}
