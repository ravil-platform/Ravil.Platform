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

        #region ( Export To Excel )
        [HttpGet]
        public async Task<IActionResult> ExportActionsToExcel()
        {
            var fileBytes = await UnitOfWork.ActionHistoriesRepository.ExportDataToExcel();

            var fileName = $"test_interactions.xlsx";

            return File(fileBytes,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileName);
        }
        #endregion

        #region ( Export To Excel )
        [HttpGet]
        public async Task<IActionResult> ExportUsersToExcel()
        {
            var fileBytes = await UnitOfWork.ApplicationUserRepository.ExportDataToExcel();

            var fileName = $"test_users.xlsx";

            return File(fileBytes,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileName);
        }
        #endregion

        #region ( Export To Excel )
        [HttpGet]
        public async Task<IActionResult> ExportJobsToExcel()
        {
            var fileBytes = await UnitOfWork.JobRepository.ExportDataToExcel();

            var fileName = $"test_jobs_data.xlsx";

            return File(fileBytes,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileName);
        }
        #endregion
    }
}
