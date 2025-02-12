using Common.Utilities.Services.FTP;
using ViewModels.AdminPanel.Filter;

namespace Admin.MVC.Controllers;

public class StateController : BaseController
{
    #region ( DI )
    protected IMapper Mapper { get; }
    protected IUnitOfWork UnitOfWork { get; }
    protected IFtpService FtpService { get; }
    public StateController(IMapper mapper, IUnitOfWork unitOfWork, IFtpService ftpService)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
        FtpService = ftpService;
    }
    #endregion

    #region ( Index )
    [HttpGet]
    public IActionResult Index(StateBaseFilterViewModel filter)
    {
        return View(UnitOfWork.StateBaseRepository.GetByFilter(filter));
    }
    #endregion
}