using DocumentFormat.OpenXml.Office2013.Drawing.ChartStyle;
using Domain.Entities.Wallets;
using Enums;
using ViewModels.AdminPanel.Filter;
using ViewModels.AdminPanel.Wallet;

namespace Admin.MVC.Controllers;

public class WalletController(
    IUnitOfWork unitOfWork,
    IMapper mapper)
    : BaseController
{
    #region ( DI )
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    protected IMapper Mapper { get; } = mapper;
    #endregion

    #region ( Index )
    [HttpGet]
    public async Task<IActionResult> Index(WalletFilterViewModel filter)
    {
        var users = await UnitOfWork.ApplicationUserRepository.GetAllAsync();

        ViewData["users"] = users;

        return View(UnitOfWork.WalletRepository.GetByFilter(filter));
    }
    #endregion

    #region ( Create )
    [HttpGet]
    public async Task<IActionResult> ChargeWallet()
    {
        var users = await UnitOfWork.ApplicationUserRepository.GetAllAsync();

        ViewData["users"] = users;

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> ChargeWallet(CreateWalletViewModel createWalletViewModel)
    {
        var existWallet =
            await UnitOfWork.WalletRepository.GetByPredicate(w => w.ApplicationUserId == createWalletViewModel.UserId);

        try
        {
            if (existWallet != null)
            {
                existWallet.Inventory += createWalletViewModel.Inventory;

                //ToDo : Add a field to this table for check transaction Is from admin or no?

                #region ( Create Transaction )
                var transaction = new Transaction()
                {
                    AuthCode = null,
                    PaymentId = null,
                    RefId = null,
                    TrackingCode = null,
                    Status = TransactionStatus.Success,
                    TransactionDate = DateTime.Now,
                };

                await UnitOfWork.TransactionRepository.InsertAsync(transaction);
                await UnitOfWork.SaveAsync();
                #endregion

                #region ( Update Wallet )
                await UnitOfWork.WalletRepository.UpdateAsync(existWallet);
                await UnitOfWork.SaveAsync();
                #endregion

                #region ( Create Wallet Transaction )
                var walletTransaction = new WalletTransaction()
                {
                    WalletId = existWallet.Id,
                    Amount = createWalletViewModel.Inventory,
                    IsConfirmed = true,
                    CreateDate = DateTime.Now,
                    TransactionType = WalletTransactionType.Deposit,
                    TransactionId = transaction.Id,
                };

                await UnitOfWork.WalletTransactionRepository.InsertAsync(walletTransaction);
                await UnitOfWork.SaveAsync();
                #endregion
            }
            else
            {
                //ToDo : Add a field to this table for check transaction Is from admin or no?

                #region ( Create Transaction )
                var transaction = new Transaction()
                {
                    AuthCode = null,
                    PaymentId = null,
                    RefId = null,
                    TrackingCode = null,
                    Status = TransactionStatus.Success,
                    TransactionDate = DateTime.Now,
                };

                await UnitOfWork.TransactionRepository.InsertAsync(transaction);
                await UnitOfWork.SaveAsync();
                #endregion

                #region ( Create Wallet )
                var wallet = new Wallet()
                {
                    Inventory = createWalletViewModel.Inventory,
                    ApplicationUserId = createWalletViewModel.UserId,
                };

                await UnitOfWork.WalletRepository.InsertAsync(wallet);
                await UnitOfWork.SaveAsync();
                #endregion

                #region ( Create Wallet Transaction )
                var walletTransaction = new WalletTransaction()
                {
                    WalletId = wallet.Id,
                    Amount = createWalletViewModel.Inventory,
                    IsConfirmed = true,
                    CreateDate = DateTime.Now,
                    TransactionType = WalletTransactionType.Deposit,
                    TransactionId = transaction.Id,
                };

                await UnitOfWork.WalletTransactionRepository.InsertAsync(walletTransaction);
                await UnitOfWork.SaveAsync();
                #endregion
            }

            SuccessAlert();
        }
        catch (Exception exception)
        {
            ErrorAlert(exception.Message);
        }

        return RedirectToAction("Index");
    }

    #endregion
}