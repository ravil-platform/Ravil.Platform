using ViewModels.AdminPanel.User;

namespace Admin.MVC.Controllers
{
    public class UsersController : BaseController
    {
        #region ( DI )
        protected UserManager<ApplicationUser> UserManager { get; }
        protected IUnitOfWork UnitOfWork { get; }
        protected IMapper Mapper { get; }
        public UsersController(IUnitOfWork unitOfWork, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
            UserManager = userManager;
        }
        #endregion

        #region ( Index )
        public IActionResult Index(UsersFilterViewModel usersFilterViewModel)
        {
            return View(UnitOfWork.ApplicationUserRepository.GetUsersByFilter(usersFilterViewModel));
        }
        #endregion

        #region ( Create )
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserViewModel createUserViewModel)
        {
            if (!ModelState.IsValid)
            {
                ErrorAlert(Errors.ModelStateIsNotValidForm);

                return RedirectToAction("Index");
            }

            var user = Mapper.Map<ApplicationUser>(createUserViewModel);

            await UnitOfWork.ApplicationUserRepository.InsertAsync(user);

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
        public async Task<IActionResult> Update(Guid id)
        {
            var user = await UnitOfWork.ApplicationUserRepository.GetByIdAsync(id);

            var model = Mapper.Map<UpdateUserViewModel>(user);

            return PartialView("_Update", model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateUserViewModel updateUserViewModel, bool detailPage = false)
        {
            var user = await UnitOfWork.ApplicationUserRepository.GetByIdAsync(updateUserViewModel.Id);

            user = Mapper.Map(updateUserViewModel, user);

            await UserManager.UpdateAsync(user);

            try
            {
                await UnitOfWork.SaveAsync();

                SuccessAlert();
            }
            catch (Exception e)
            {
                ErrorAlert(e.Message);
            }

            return detailPage ? RedirectToAction("Detail", new { Id = user.Id }) : RedirectToAction("Index");
        }
        #endregion


        #region ( Detail )
        [HttpGet]
        public async Task<IActionResult> Detail(Guid id)
        {
            var model = await UnitOfWork.ApplicationUserRepository.GetByIdAsync(id);

            return View(model);
        }
        #endregion


        #region ( Remove )
        [HttpPost]
        public async Task<IActionResult> Remove(Guid id)
        {
            await UnitOfWork.ApplicationUserRepository.RemoveAsync(id);

            try
            {
                await UnitOfWork.SaveAsync();

                SuccessAlert();
            }
            catch (Exception ex)
            {
                ErrorAlert(ex.Message);
            }

            return RedirectToAction("Detail", new { Id = id });
        }
        #endregion

        #region ( Delete )
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            await UnitOfWork.ApplicationUserRepository.DeleteAsync(id);

            try
            {
                await UnitOfWork.SaveAsync();

                SuccessAlert();
            }
            catch (Exception ex)
            {
                ErrorAlert(ex.Message);
            }

            return RedirectToAction("Detail", new { Id = id });
        }
        #endregion

        #region ( Restore )
        [HttpPost]
        public async Task<IActionResult> Restore(Guid id)
        {
            await UnitOfWork.ApplicationUserRepository.RestoreAsync(id);

            try
            {
                await UnitOfWork.SaveAsync();

                SuccessAlert();
            }
            catch (Exception ex)
            {
                ErrorAlert(ex.Message);
            }

            return RedirectToAction("Detail", new { Id = id });
        }
        #endregion


        #region ( Lock )
        [HttpPost]
        public async Task<IActionResult> Lock(Guid id, string lockoutReason)
        {
            var result = await UnitOfWork.ApplicationUserRepository.LockAsync(id, lockoutReason, UserManager);

            if (result == false)
            {
                ErrorAlert();

                return RedirectToAction("Detail", new { Id = id });
            }

            try
            {
                await UnitOfWork.SaveAsync();

                SuccessAlert();
            }
            catch (Exception ex)
            {
                ErrorAlert(ex.Message);
            }

            return RedirectToAction("Detail", new { Id = id });
        }
        #endregion

        #region ( Un Lock )
        [HttpPost]
        public async Task<IActionResult> UnLock(Guid id)
        {
            await UnitOfWork.ApplicationUserRepository.UnLockAsync(id, UserManager);

            try
            {
                await UnitOfWork.SaveAsync();

                SuccessAlert();
            }
            catch (Exception ex)
            {
                ErrorAlert(ex.Message);
            }

            return RedirectToAction("Detail", new { Id = id });
        }
        #endregion


        #region ( Confirm Phone )
        [HttpPost]
        public async Task<IActionResult> ConfirmPhone(Guid id)
        {
            await UnitOfWork.ApplicationUserRepository.ConfirmPhoneAsync(id);

            try
            {
                await UnitOfWork.SaveAsync();

                SuccessAlert();
            }
            catch (Exception ex)
            {
                ErrorAlert(ex.Message);
            }

            return RedirectToAction("Detail", new { Id = id });
        }
        #endregion

        #region ( Un Confirm Phone )
        [HttpPost]
        public async Task<IActionResult> UnConfirmPhone(Guid id)
        {
            await UnitOfWork.ApplicationUserRepository.UnConfirmPhoneAsync(id);

            try
            {
                await UnitOfWork.SaveAsync();

                SuccessAlert();
            }
            catch (Exception ex)
            {
                ErrorAlert(ex.Message);
            }

            return RedirectToAction("Detail", new { Id = id });
        }
        #endregion


        #region ( Confirm Email )
        [HttpPost]
        public async Task<IActionResult> ConfirmEmail(Guid id)
        {
            await UnitOfWork.ApplicationUserRepository.ConfirmEmailAsync(id);

            try
            {
                await UnitOfWork.SaveAsync();

                SuccessAlert();
            }
            catch (Exception ex)
            {
                ErrorAlert(ex.Message);
            }

            return RedirectToAction("Detail", new { Id = id });
        }
        #endregion

        #region ( Un Confirm Email )
        [HttpPost]
        public async Task<IActionResult> UnConfirmEmail(Guid id)
        {
            await UnitOfWork.ApplicationUserRepository.UnConfirmEmailAsync(id);

            try
            {
                await UnitOfWork.SaveAsync();

                SuccessAlert();
            }
            catch (Exception ex)
            {
                ErrorAlert(ex.Message);
            }

            return RedirectToAction("Detail", new { Id = id });
        }
        #endregion
    }
}
