namespace Admin.MVC.Controllers;

public class PanelTutorialController(IMapper mapper, IUnitOfWork unitOfWork, IFtpService ftpService)
    : BaseController
{
    #region ( DI )
    protected IMapper Mapper { get; } = mapper;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected IFtpService FtpService { get; } = ftpService;
    #endregion

    #region ( Index )
    [HttpGet]
    public IActionResult Index(PanelTutorialFilterViewModel filter)
    {
        return View(UnitOfWork.PanelTutorialRepository.GetByFilter(filter));
    }
    #endregion

    #region ( Create )
    [HttpPost]
    public async Task<IActionResult> Create(CreatePanelTutorialViewModel createPanelTutorialViewModel)
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

        var panelTutorial = Mapper.Map<PanelTutorial>(createPanelTutorialViewModel);

        #region ( Upload Files )
        #region ( Cover )
        var coverName = await FtpService.UploadFileToFtpServer(createPanelTutorialViewModel.CoverNameFile, TypeFile.Image, Paths.PanelTutorialImagePath, createPanelTutorialViewModel.CoverNameFile.FileName);

        panelTutorial.CoverName = coverName;
        #endregion

        #region ( Video )
        var videoName = await FtpService.UploadFileToFtpServer(createPanelTutorialViewModel.VideoNameFile, TypeFile.Video, Paths.PanelTutorialVideoPath, createPanelTutorialViewModel.CoverNameFile.FileName);

        panelTutorial.VideoName = videoName;
        #endregion
        #endregion

        await UnitOfWork.PanelTutorialRepository.InsertAsync(panelTutorial);

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
        var panelTutorial = await UnitOfWork.PanelTutorialRepository.GetByIdAsync(id);

        var model = Mapper.Map<UpdatePanelTutorialViewModel>(panelTutorial);

        return PartialView("_Update", model);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdatePanelTutorialViewModel updatePanelTutorialViewModel)
    {
        var panelTutorial = await UnitOfWork.PanelTutorialRepository.GetByIdAsync(updatePanelTutorialViewModel.Id);

        if (panelTutorial == null)
        {
            #region ( Panel Is Null )
            ErrorAlert("چیزی یافت نشد!");

            return RedirectToAction("Index");
            #endregion
        }

        panelTutorial = Mapper.Map(updatePanelTutorialViewModel, panelTutorial);

        #region ( Cover )
        if (updatePanelTutorialViewModel.NewCoverNameFile != null)
        {
            var deletedFile = "";

            if (panelTutorial.CoverName != null)
            {
                deletedFile = panelTutorial.CoverName;
            }

            var coverName = await FtpService.UploadFileToFtpServer(updatePanelTutorialViewModel.NewCoverNameFile, TypeFile.Image, Paths.PanelTutorialImagePath, updatePanelTutorialViewModel.NewCoverNameFile.FileName, 777, null, null, null, deletedFile);

            panelTutorial.CoverName = coverName;
        }
        #endregion

        #region ( Video )
        if (updatePanelTutorialViewModel.NewVideoNameFile != null)
        {
            var deletedFile = "";

            if (panelTutorial.VideoName != null)
            {
                deletedFile = panelTutorial.VideoName;
            }

            var videoName = await FtpService.UploadFileToFtpServer(updatePanelTutorialViewModel.NewVideoNameFile, TypeFile.Video, Paths.PanelTutorialVideoPath, updatePanelTutorialViewModel.NewVideoNameFile.FileName, 777, null, null, null, deletedFile);

            panelTutorial.VideoName = videoName;
        }
        #endregion

        await UnitOfWork.PanelTutorialRepository.UpdateAsync(panelTutorial);

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
        var panelTutorial = await UnitOfWork.PanelTutorialRepository.GetByIdAsync(id);

        if (panelTutorial == null)
        {
            ErrorAlert("چیزی یافت نشد!");

            return RedirectToAction("Index");
        }

        try
        {
            await UnitOfWork.PanelTutorialRepository.DeleteAsync(panelTutorial);
            await UnitOfWork.SaveAsync();

            #region ( Delete Cover And Video )
            await FtpService.DeleteFileToFtpServer(Paths.PanelTutorialImagePath, panelTutorial.CoverName);
            await FtpService.DeleteFileToFtpServer(Paths.PanelTutorialVideoPath, panelTutorial.VideoName);
            #endregion
        }
        catch (Exception exception)
        {
            ErrorAlert(exception.Message);
        }

        return RedirectToAction("Index");
    }
    #endregion
}