using Common.Utilities.Services.FTP;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using ViewModels.AdminPanel.Filter;

namespace Admin.MVC.Controllers
{
    public class ContactController : BaseController
    {
        #region ( DI )
        protected IMapper Mapper { get; }
        protected IUnitOfWork UnitOfWork { get; }
        protected IFtpService FtpService { get; }
        public ContactController(IMapper mapper, IUnitOfWork unitOfWork, IFtpService ftpService)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            FtpService = ftpService;
        }
        #endregion

        #region ( Index )
        [HttpGet]
        public IActionResult Index(ContactFormFilterAdminViewModel filter)
        {
            return View(UnitOfWork.ContactusRepository.GetByFilter(filter));
        }
        #endregion

        #region ( Read )
        [HttpGet]
        public async Task<IActionResult> Read(int id)
        {
            var model = await UnitOfWork.ContactusRepository.GetByIdAsync(id);

            model.IsReadByAdmin = true;
            await UnitOfWork.ContactusRepository.UpdateAsync(model);
            await UnitOfWork.SaveAsync();

            return PartialView("_ReadContactForm", model);
        }
        #endregion

        #region ( RemoveSpam )
        [HttpGet]
        public async Task<IActionResult> RemoveSpam()
        {
            try
            {
                string pattern = @"^(?:0|98|\+98|\+980|0098|098|00980)?(9\d{9})$";

                var allContactUs = await UnitOfWork.ContactusRepository.Table.ToListAsync();
                var spamMessages = allContactUs
                    .Where(m => !Regex.IsMatch(m.PhoneNumber, pattern))
                    .ToList();

                UnitOfWork.ContactusRepository.RemoveRange(spamMessages);
                await UnitOfWork.SaveAsync();


                SuccessAlert("تمامی اسپم ها پاک شدند");
            }
            catch
            {
                ErrorAlert("درخواست انجام نشد در زمان دیگری امتحان کنید");
            }

            return RedirectToAction("Index");
        }
        #endregion
    }
}
