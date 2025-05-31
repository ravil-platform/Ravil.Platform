namespace Admin.MVC.Controllers
{
    public class HomeController(IUnitOfWork unitOfWork) : BaseController
    {
        protected IUnitOfWork UnitOfWork { get; } = unitOfWork;

        public async Task<IActionResult> Index()
        {
            // امروز کاربر های ثبت نام شده
            #region ( Registered Users Count )
            var todayUsersCount = await UnitOfWork.ApplicationUserRepository.TableNoTracking
                .Where(u => u.RegisterDate.Date == DateTime.Now.Date).CountAsync();
            ViewData["todayUsersCount"] = todayUsersCount;
            #endregion

            //تعداد کل کاربران
            #region ( Users Count )
            var usersCount = await UnitOfWork.ApplicationUserRepository.TableNoTracking.CountAsync();
            ViewData["usersCount"] = usersCount;
            #endregion


            //تعداد کل مشاغل ثبت شده 
            #region ( Job )
            var jobCount = await UnitOfWork.JobRepository.TableNoTracking.CountAsync();
            ViewData["jobCount"] = jobCount;
            #endregion


            //تعداد کل مشاغل نیاز به بررسی 
            #region ( Job Wating )
            var jobWaitingCount = await UnitOfWork.JobRepository.TableNoTracking.Where(j => j.Status == JobBranchStatus.WaitingToCheck).CountAsync();
            ViewData["jobWaitingCount"] = jobWaitingCount;
            #endregion


            //تعداد تماس با ما ثبت شده 
            #region ( Contact  )
            var contactCount = await UnitOfWork.ContactusRepository.TableNoTracking.Where(c => c.IsReadByAdmin == false).CountAsync();
            ViewData["contactCount"] = contactCount;
            #endregion


            //تعداد دیدگاه های ثبت شده
            #region ( Feedback )
            var feedbackCount = await UnitOfWork.FeedbackSliderRepository.TableNoTracking.CountAsync();
            ViewData["feedbackCount"] = feedbackCount;
            #endregion

            return View();
        }

        //public async Task<IActionResult> Test()
        //{
        //    return Content(
        //        $"RemoteIpAddress :{HttpContext.Connection.RemoteIpAddress?.ToString()}\n LocalIpAddress :{HttpContext.Connection.LocalIpAddress?.ToString()}");
        //}

        [HttpGet]
        public async Task<IActionResult> Test()
        {
            var random = new Random();

            var users = await UnitOfWork.ApplicationUserRepository.TableNoTracking.ToListAsync();

            var subscriptions = await UnitOfWork.SubscriptionRepository.TableNoTracking.Where(t => t.IsActive).ToListAsync();

            var paymentPortals = await UnitOfWork.PaymentPortalRepository.TableNoTracking.ToListAsync();


            for (int i = 0; i < 632; i++)
            {
                var user = users[random.Next(users.Count)];
                var subscription = subscriptions[random.Next(subscriptions.Count)];

                var startDate = RandomDateWithinLastMonths(7);
                var endDate = startDate.AddDays(subscription.DurationTime);

                // ساخت UserSubscription
                var existUserSubscription =
                    await UnitOfWork.UserSubscriptionRepository
                        .TableNoTracking.FirstOrDefaultAsync(u => u.UserId == user.Id && u.SubscriptionId == subscription.Id);

                int userSubscriptionId = 0;

                if (existUserSubscription != null)
                {
                    existUserSubscription.BuyCount += 1;

                    userSubscriptionId = existUserSubscription.Id;
                }
                else
                {
                    var userSubscription = new UserSubscription
                    {
                        UserId = user.Id,
                        SubscriptionId = subscription.Id,
                        StartDate = startDate,
                        EndDate = endDate,
                        BuyCount = 1,
                        IsActive = true,
                        IsFinally = true
                    };
                    await UnitOfWork.UserSubscriptionRepository.InsertAsync(userSubscription);
                    await UnitOfWork.SaveAsync();

                    userSubscriptionId = userSubscription.Id;
                }


                // ساخت Payment
                var paymentMethods = Enum.GetValues(typeof(PaymentMethod)).Cast<PaymentMethod>().ToList();

                var currentPayment =
                    await UnitOfWork.PaymentRepository.GetByPredicate(p => p.UserSubscriptionId == userSubscriptionId);

                Guid paymentId = Guid.Empty;

                if (currentPayment != null)
                {
                    paymentId = currentPayment.Id;
                    currentPayment.RenewalDate = currentPayment.PaymentDate.AddDays(subscription.DurationTime + random.Next(30, 120));

                    await UnitOfWork.PaymentRepository.UpdateAsync(currentPayment);
                    await UnitOfWork.SaveAsync();
                }
                else
                {
                    var payment = new Payment
                    {
                        Id = Guid.NewGuid(),
                        Number = $"PMT-{random.Next(100000, 999999)}",
                        Amount = subscription.Price,
                        PaymentDate = startDate,
                        PaymentMethod = paymentMethods[random.Next(paymentMethods.Count)],
                        UserSubscriptionId = userSubscriptionId,
                        PaymentPortalId = paymentPortals[random.Next(paymentPortals.Count)].Id
                    };
                    await UnitOfWork.PaymentRepository.InsertAsync(payment);
                    await UnitOfWork.SaveAsync();

                    paymentId = payment.Id;
                }

                // ساخت Transaction
                var transactionStatus = Enum.GetValues(typeof(TransactionStatus)).Cast<TransactionStatus>().ToList();

                var transaction = new Transaction
                {
                    Id = Guid.NewGuid(),
                    Number = $"TRX-{random.Next(1000000, 9999999)}",
                    Amount = subscription.Price.ToString(),
                    TransactionDate = startDate.AddMinutes(random.Next(10, 1000)),
                    Status = transactionStatus[random.Next(transactionStatus.Count)],
                    AuthCode = random.Next(100000, 99999999).ToString(), // بین 6 تا 8 رقمی
                    TrackingCode = $"TRK-{random.Next(100000, 999999)}",
                    PaymentId = paymentId
                };

                transaction.RefId = transaction.Status == TransactionStatus.Success
                    ? $"{random.Next(1000_0000, 9999_9999)}{random.Next(1000_0000, 9999_9999)}"
                    : null;

                await UnitOfWork.TransactionRepository.InsertAsync(transaction);
            }

            await UnitOfWork.SaveAsync();

            return Ok("632 تراکنش فیک با موفقیت ایجاد شد.");
        }

        // متد برای تاریخ تصادفی
        private DateTime RandomDateWithinLastMonths(int monthsBack)
        {
            var end = DateTime.Now;
            var start = end.AddMonths(-monthsBack);
            var range = (end - start).Days;
            return start.AddDays(new Random().Next(range));
        }
    }
}
