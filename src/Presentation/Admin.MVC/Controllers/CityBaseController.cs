namespace Admin.MVC.Controllers;

public class CityBaseController(IMapper mapper, IUnitOfWork unitOfWork, IFtpService ftpService)
    : BaseController
{
    #region ( DI )
    protected IMapper Mapper { get; } = mapper;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected IFtpService FtpService { get; } = ftpService;

    #endregion

    #region ( Index )
    [HttpGet]
    public async Task<IActionResult> Index(CityBaseFilterViewModel filter)
    {
        ViewData["states"] = await UnitOfWork.StateBaseRepository.GetAllAsync();

        return View(UnitOfWork.CityBaseRepository.GetByFilterAdmin(filter));
    }
    #endregion

    #region ( City )
    #region ( Index )
    [HttpGet]
    public IActionResult IndexCity(CityFilterViewModel filter)
    {
        return View(UnitOfWork.CityRepository.GetByFilterAdmin(filter));
    }
    #endregion

    #region ( Create )
    [HttpPost]
    public async Task<IActionResult> CreateCity(CreateCityViewModel createCityViewModel)
    {
        if (!ModelState.IsValid)
        {
            ErrorAlert(Errors.ModelStateIsNotValidForm);

            return RedirectToAction("Index");
        }

        var city = Mapper.Map<City>(createCityViewModel);

        var pictureName = await FtpService.UploadFileToFtpServer(createCityViewModel.PictureFile, TypeFile.Image, Paths.City, createCityViewModel.PictureFile.FileName);
        city.Picture = pictureName;

        await UnitOfWork.CityRepository.InsertAsync(city);

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
    #endregion

    //SEO
    #region ( Related Cities )
    #region ( Index )
    [HttpGet]
    public async Task<IActionResult> IndexRelatedCities()
    {
        var model = await UnitOfWork.JobBranchRelatedJobRepository.GetAllAsync();
        return View(model);
    }
    #endregion

    #region ( Create )
    [HttpGet]
    public async Task<IActionResult> CreateRelatedCities()
    {
        var cities = await UnitOfWork.CityRepository.GetAllAsync();
        ViewData["cities"] = cities;

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateRelatedCities(int currentCityId, string hiddenDisplayedCityIds, JobBranchRelatedJob jobBranchRelatedJob)
    {
        string[] hiddenDisplayedCityIdsArray = hiddenDisplayedCityIds.Split(',');

        if (currentCityId == null || hiddenDisplayedCityIdsArray.Length == 0)
        {
            ErrorAlert("مقادیر نباید خالی باشند.");

            return RedirectToAction("IndexRelatedCities");
        }

        try
        {
            var currentCity = await UnitOfWork.CityRepository.GetByPredicate(c => c.Id == currentCityId);

            if (currentCity == null)
            {
                ErrorAlert("شهر یافت نشد.");

                return RedirectToAction("IndexRelatedCities");
            }

            int sort = jobBranchRelatedJob.Sort;

            foreach (var displayedCityId in hiddenDisplayedCityIdsArray)
            {
                var displayedCity = await UnitOfWork.CityRepository.GetByPredicate(c => c.Id == Convert.ToInt32(displayedCityId));

                var newJobBranchRelatedJob = new JobBranchRelatedJob()
                {
                    CurrentCityId = currentCity.CityBaseId,
                    CurrentCityName = currentCity.Subtitle,

                    DisplayedCityId = displayedCity.CityBaseId,
                    DisplayedCityName = displayedCity.Subtitle,

                    Sort = sort,
                };

                await UnitOfWork.JobBranchRelatedJobRepository.InsertAsync(newJobBranchRelatedJob);

                sort++;
            }

            await UnitOfWork.SaveAsync();

            SuccessAlert();
        }
        catch (Exception e)
        {
            ErrorAlert($"{e.InnerException?.Message ?? e.Message}");
        }

        return RedirectToAction("IndexRelatedCities");
    }
    #endregion

    #region ( Delete )
    [HttpGet]
    public async Task<IActionResult> DeleteRelatedCities(int id)
    {
        var jobBranchRelatedJob = await UnitOfWork.JobBranchRelatedJobRepository.GetByPredicate(t => t.Id == id);

        if (jobBranchRelatedJob != null)
        {
            await UnitOfWork.JobBranchRelatedJobRepository.DeleteAsync(jobBranchRelatedJob);
        }

        try
        {
            await UnitOfWork.SaveAsync();

            SuccessAlert();
        }
        catch
        {
            ErrorAlert();
        }

        return RedirectToAction("IndexRelatedCities");
    }
    #endregion
    #endregion
}