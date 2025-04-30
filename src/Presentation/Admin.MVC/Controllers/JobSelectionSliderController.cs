namespace Admin.MVC.Controllers;

public class JobSelectionSliderController(IUnitOfWork unitOfWork) : BaseController
{
    #region ( DI )
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    #endregion
}