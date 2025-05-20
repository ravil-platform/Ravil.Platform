

namespace Admin.MVC.Controllers;

public class StateController(IMapper mapper, IUnitOfWork unitOfWork) : BaseController
{
    #region ( DI )
    protected IMapper Mapper { get; } = mapper;
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;

    #endregion

    #region ( Index )
    [HttpGet]
    public IActionResult Index(StateBaseFilterViewModel filter)
    {
        return View(UnitOfWork.StateBaseRepository.GetByFilterAdmin(filter));
    }
    #endregion

    #region ( Create )
    [HttpPost]
    public async Task<IActionResult> Create(CreateStateBaseViewModel createStateBaseViewModel)
    {
        if (!ModelState.IsValid)
        {
            ErrorAlert(Errors.ModelStateIsNotValidForm);

            return RedirectToAction("Index");
        }

        var stateBase = new StateBase()
        {
            Name = createStateBaseViewModel.Name,
            Multiplier = createStateBaseViewModel.Multiplier,
        };

        await UnitOfWork.StateBaseRepository.InsertAsync(stateBase);

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
        var stateBase = await UnitOfWork.StateBaseRepository.GetByIdAsync(id);

        var model = new UpdateStateBaseViewModel()
        {
            Id = stateBase.Id,
            Name = stateBase.Name,
            Multiplier = stateBase.Multiplier
        };

        return PartialView("_Update", model);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateStateBaseViewModel updateStateBaseViewModel)
    {
        var stateBase = await UnitOfWork.StateBaseRepository.GetByIdAsync(updateStateBaseViewModel.Id);

        stateBase.Name = updateStateBaseViewModel.Name;
        stateBase.Multiplier = updateStateBaseViewModel.Multiplier;

        await UnitOfWork.StateBaseRepository.UpdateAsync(stateBase);

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
        var stateBase = await UnitOfWork.StateBaseRepository.GetByIdAsync(id);

        await UnitOfWork.StateBaseRepository.DeleteAsync(stateBase);

        try
        {
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
}