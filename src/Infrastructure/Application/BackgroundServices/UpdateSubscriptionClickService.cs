using Logging.Base;
using Domain.Entities.Wallets;
using System.Security.Cryptography;

namespace Application.BackgroundServices
{
    public class UpdateSubscriptionClickService(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        UserManager<ApplicationUser> userManager,
        IHttpContextAccessor httpContextAccessor,
        ILogger<UpdateSubscriptionClickService> logger)
    {
        #region ( Properties )
        protected IMapper Mapper { get; } = mapper;
        protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
        protected UserManager<ApplicationUser> UserManager { get; } = userManager;
        protected HttpContext? HttpContext { get; } = httpContextAccessor.HttpContext;
        protected IHttpContextAccessor HttpContextAccessor { get; } = httpContextAccessor;
        protected Logging.Base.ILogger<UpdateSubscriptionClickService> Logger { get; } = logger;
        #endregion

        #region ( Methods )
        
        public async Task UpdateSubscriptionClicks()
        {
            try
            {
                await UnitOfWork.BeginTransactionAsync(cancellationToken: CancellationToken.None);

                var subscriptionsClicks = await UnitOfWork.SubscriptionClickRepository.Table
                    .Include(a => a.Click).Include(a => a.Job)
                    .Where(a => !a.IsDeposit && a.ClickedTime.Day == DateTime.UtcNow.Day)
                    .ToListAsync();

                if (!subscriptionsClicks.Any()) return;

                bool hasSaveChanges = false;
                foreach (var subscriptionsClickJobId in subscriptionsClicks.Select(a => a.JobId).Distinct().ToList())
                {
                    var businessOwner = await UnitOfWork.JobBranchRepository.TableNoTracking
                        .SingleOrDefaultAsync(a => a.JobId == subscriptionsClickJobId && a.Status == JobBranchStatus.Accepted);
                    if (businessOwner is null) continue;

                    var userWallet = await UnitOfWork.WalletRepository.TableNoTracking.SingleOrDefaultAsync(a => a.ApplicationUserId == businessOwner.Id);
                    if (userWallet is not null)
                    {
                        var userSubsClicks = subscriptionsClicks.Where(a => a.JobId == businessOwner.JobId).ToList();
                        var userSubsClicksPriceTotal = Convert.ToDouble(userSubsClicks.Sum(a => a.CostPerClick));

                        #region ( Handle Harvest Transactions )

                        var orderAuthCode = "Harvest_" + Strings.RandomString();
                        var generateNumber = RandomNumberGenerator.GetString(new ReadOnlySpan<char>(['1', '2', '3', '4', '5', '6', '7', '8', '9']), 7);

                        var newTransaction = new Transaction
                        {
                            Number = generateNumber,
                            AuthCode = orderAuthCode,
                            Status = TransactionStatus.Success,
                            Amount = $"{userSubsClicksPriceTotal}",
                        };

                        await UnitOfWork.TransactionRepository.InsertAsync(newTransaction);
                        await UnitOfWork.SaveAsync();

                        var walletTransaction = new WalletTransaction
                        {
                            IsConfirmed = true,
                            WalletId = userWallet.Id,
                            CreateDate = DateTime.Now,
                            TransactionId = newTransaction.Id,
                            Amount = userSubsClicksPriceTotal,
                            TransactionType = WalletTransactionType.Harvest,
                        };

                        await UnitOfWork.WalletTransactionRepository.InsertAsync(walletTransaction);

                        #endregion

                        var saveResponse = await UnitOfWork.SaveAsync();
                        if (saveResponse > 0)
                        {
                            userWallet.Inventory -= userSubsClicksPriceTotal;

                            await UnitOfWork.WalletRepository.UpdateAsync(userWallet);
                            await UnitOfWork.SaveAsync();

                            hasSaveChanges = true;
                        }
                    }
                }

                if (hasSaveChanges)
                {
                    await UnitOfWork.CommitTransactionAsync(cancellationToken: CancellationToken.None);
                }
            }
            catch (Exception e)
            {
                await UnitOfWork.RollbackTransactionAsync(cancellationToken: CancellationToken.None);
                Logger.LogError(message: e.InnerException?.Message ?? e.Message);

                throw;
            }
        }

        #endregion
    }
}
