namespace Admin.MVC.Controllers;

public class MessageBoxController(IUnitOfWork unitOfWork, IMapper mapper) : BaseController
{
    #region ( DI )
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected IMapper Mapper { get; } = mapper;
    #endregion

    #region ( Index )
    [HttpGet]
    public async Task<IActionResult> Index(MessageBoxFilterViewModel filter)
    {
        var jobs = await UnitOfWork.JobRepository.TableNoTracking
            .Include(j => j.JobBranches)
            .Where(j => j.JobBranches.Count != 0).ToListAsync();

        ViewData["jobs"] = jobs;

        return View(UnitOfWork.MessageBoxRepository.GetByFilter(filter));
    }
    #endregion

    #region ( Create )
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var jobs = await UnitOfWork.JobRepository.TableNoTracking
            .Include(j => j.JobBranches)
            .Where(j => j.JobBranches.Count != 0).ToListAsync();

        ViewData["jobs"] = jobs;

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateMessageBoxViewModel createMessageBoxViewModel)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();

            ErrorAlert($"{Errors.ModelStateIsNotValidForm} - ارور : {errors[0]}");

            #region ( Fill View Datas )
            var jobs = await UnitOfWork.JobRepository.TableNoTracking
                .Include(j => j.JobBranches)
                .Where(j => j.JobBranches.Count != 0).ToListAsync();

            ViewData["jobs"] = jobs;
            #endregion

            return RedirectToAction("Index");
        }

        var messageBox = Mapper.Map<MessageBox>(createMessageBoxViewModel);

        await UnitOfWork.MessageBoxRepository.InsertAsync(messageBox);

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
        var messageBox = await UnitOfWork.MessageBoxRepository.GetByIdAsync(id);

        if (messageBox == null)
        {
            return RedirectToAction("Index");
        }

        var model = Mapper.Map<UpdateMessageBoxViewModel>(messageBox);

        #region ( Fill View Datas )
        var jobs = await UnitOfWork.JobRepository.TableNoTracking
            .Include(j => j.JobBranches)
            .Where(j => j.JobBranches.Count != 0).ToListAsync();

        ViewData["jobs"] = jobs;
        #endregion

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateMessageBoxViewModel updateMessageBoxViewModel)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();

            ErrorAlert($"{Errors.ModelStateIsNotValidForm} - ارور :\n {errors[0]}");

            #region ( Fill View Datas )
            var jobs = await UnitOfWork.JobRepository.TableNoTracking
                .Include(j => j.JobBranches)
                .Where(j => j.JobBranches.Count != 0).ToListAsync();

            ViewData["jobs"] = jobs;
            #endregion

            return View(updateMessageBoxViewModel);
        }

        var messageBox = await UnitOfWork.MessageBoxRepository.GetByIdAsync(updateMessageBoxViewModel.Id);

        if (messageBox == null)
        {
            return RedirectToAction("Index");
        }

        messageBox = Mapper.Map(updateMessageBoxViewModel, messageBox);

        try
        {
            await UnitOfWork.MessageBoxRepository.UpdateAsync(messageBox);

            await UnitOfWork.SaveAsync();
        }
        catch (Exception exception)
        {
            ErrorAlert(exception.Message);
        }

        return RedirectToAction("Index");
    }
    #endregion

    #region ( Delete )

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var messageBox = await UnitOfWork.MessageBoxRepository.GetByIdAsync(id);

            await UnitOfWork.MessageBoxRepository.DeleteAsync(messageBox);

            await UnitOfWork.SaveAsync();
        }
        catch (Exception exception)
        {
            ErrorAlert(exception.Message);
        }

        return RedirectToAction("Index");
    }


    #endregion

    #region ( Show Message Box )
    [HttpGet]
    public async Task<IActionResult> ShowMessageBox(int id)
    {
        var model = await UnitOfWork.MessageBoxRepository.TableNoTracking
            .Include(m => m.Job)
            .Where(m => m.Id == id)
            .FirstOrDefaultAsync();

        return PartialView("_ShowMessageBox", model);
    }
    #endregion
}