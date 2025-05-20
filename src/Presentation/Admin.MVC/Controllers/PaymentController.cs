

namespace Admin.MVC.Controllers;

public class PaymentController(
    IUnitOfWork unitOfWork,
    IMapper mapper,
    IFtpService ftpService,
    ISmsSender smsSender,
    UserManager<ApplicationUser> userManager)
: BaseController
{
    #region ( DI )
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected IMapper Mapper { get; } = mapper;
    protected IFtpService FtpService { get; } = ftpService;
    protected ISmsSender SmsSender { get; } = smsSender;
    protected UserManager<ApplicationUser> UserManager { get; } = userManager;
    #endregion


    #region ( Payment )

    #region ( Index )
    public async Task<IActionResult> Index(PaymentFilterViewModel filter)
    {
        var model = UnitOfWork.PaymentRepository.GetByFilter(filter);

        #region ( Payment Portals )
        var paymentPortals = await UnitOfWork.PaymentPortalRepository.GetAllAsync(p => p.IsActive);

        ViewData["paymentPortals"] = paymentPortals;
        #endregion

        return View(model);
    }
    #endregion

    #region ( Transaction )

    [HttpGet]
    public async Task<IActionResult> Transaction(Guid id)
    {
        ViewData["payment"] = await UnitOfWork.PaymentRepository.TableNoTracking.SingleOrDefaultAsync(a => a.Id == id);

        var model = UnitOfWork.TransactionRepository.GetByFilter(new TransactionFilterViewModel(){ PaymentId = id });
        
        return View(model);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> FilterTransaction(Guid id, TransactionFilterViewModel filter)
    {
        ViewData["payment"] = await UnitOfWork.PaymentRepository.TableNoTracking.SingleOrDefaultAsync(a => a.Id == id);

        var model = UnitOfWork.TransactionRepository.GetByFilter(filter);

        return View("Transaction", model);
    }
    #endregion

    #endregion

    #region ( Payment Portal )
    #region ( Index )
    public async Task<IActionResult> IndexPaymentPortal()
    {
        var model = await UnitOfWork.PaymentPortalRepository.GetAllAsync();

        return View(model.ToList());
    }
    #endregion

    #region ( Create )
    [HttpPost]
    public async Task<IActionResult> CreatePaymentPortal(CreatePaymentPortalViewModel createPaymentPortalViewModel)
    {
        if (!ModelState.IsValid)
        {
            #region ( Client Side Error )
            var errors = ModelState.Values.SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();

            ErrorAlert($"{Errors.ModelStateIsNotValidForm} - ارور : {errors[0]}");
            #endregion

            return RedirectToAction("IndexPaymentPortal");
        }

        var paymentPortal = new PaymentPortal()
        {
            Title = createPaymentPortalViewModel.Title,
            PictureName = "null"
        };

        #region ( Picture )
        if (createPaymentPortalViewModel.PictureName != null)
        {
            var pictureName = await FtpService.UploadFileToFtpServer(createPaymentPortalViewModel.PictureName, TypeFile.Image, Paths.PaymentPortal, createPaymentPortalViewModel.PictureName.FileName);

            paymentPortal.PictureName = pictureName;
        }

        await UnitOfWork.PaymentPortalRepository.InsertAsync(paymentPortal);
        #endregion

        try
        {
            await UnitOfWork.SaveAsync();

            SuccessAlert();
        }
        catch (Exception e)
        {
            ErrorAlert(e.Message);
        }

        return RedirectToAction("IndexPaymentPortal");
    }
    #endregion

    #region ( Update )
    [HttpGet]
    public async Task<IActionResult> UpdatePaymentPortal(int id)
    {
        var paymentPortal = await UnitOfWork.PaymentPortalRepository.GetByIdAsync(id);

        if (paymentPortal == null)
        {
            ErrorAlert("چیزی یافت نشد!");

            return RedirectToAction("IndexPaymentPortal");
        }

        var model = new UpdatePaymentPortalViewModel()
        {
            Title = paymentPortal.Title,
            CurrentPictureName = paymentPortal.PictureName,
        };

        return PartialView("_UpdatePaymentPortal", model);
    }

    [HttpPost]
    public async Task<IActionResult> UpdatePaymentPortal(UpdatePaymentPortalViewModel updatePaymentPortalViewModel)
    {
        var paymentPortal = await UnitOfWork.PaymentPortalRepository.GetByIdAsync(updatePaymentPortalViewModel.Id);

        paymentPortal.Title = updatePaymentPortalViewModel.Title;

        #region ( Picture Name )
        if (updatePaymentPortalViewModel.PictureName != null)
        {
            var deletedFile = "";

            if (paymentPortal.PictureName != null)
            {
                deletedFile = paymentPortal.PictureName;
            }
            var pictureName = await FtpService.UploadFileToFtpServer(updatePaymentPortalViewModel.PictureName, TypeFile.Image, Paths.PaymentPortal, updatePaymentPortalViewModel.PictureName.FileName, 777, null, null, null, deletedFile);
            paymentPortal.PictureName = pictureName;
        }
        #endregion

        await UnitOfWork.PaymentPortalRepository.UpdateAsync(paymentPortal);

        try
        {
            await UnitOfWork.SaveAsync();

            SuccessAlert();
        }
        catch (Exception e)
        {
            ErrorAlert(e.Message);
        }

        return RedirectToAction("IndexPaymentPortal");
    }
    #endregion
    #endregion
}