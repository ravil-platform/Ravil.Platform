using AutoMapper;
using Domain.Entities.User;
using FluentResults;
using ViewModels.User;

namespace Admin.MVC.Controllers
{
    public class UsersController : BaseController
    {
        #region ( DI )
        public IUnitOfWork UnitOfWork { get; }
        public IMapper Mapper { get; }
        public UsersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
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
                ErrorAlert();

                return RedirectToAction();
            }

            var user = Mapper.Map<ApplicationUser>(createUserViewModel);

            await UnitOfWork.ApplicationUserRepository.InsertAsync(user, CancellationToken.None);

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
            var user = await UnitOfWork.ApplicationUserRepository.GetByIdAsync(id, CancellationToken.None);

            var model = Mapper.Map<UpdateUserViewModel>(user);

            return PartialView("_Update", model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateUserViewModel updateUserViewModel, bool detailPage = false)
        {
            var user = await UnitOfWork.ApplicationUserRepository.GetByIdAsync(updateUserViewModel.Id, CancellationToken.None);

            user = Mapper.Map(updateUserViewModel, user);

            await UnitOfWork.ApplicationUserRepository.UpdateAsync(user, CancellationToken.None);

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
            var model = await UnitOfWork.ApplicationUserRepository.GetByIdAsync(id, CancellationToken.None);

            return View(model);
        }
        #endregion


        #region ( Remove )
        [HttpPost]
        public async Task<IActionResult> Remove(Guid id)
        {
            await UnitOfWork.ApplicationUserRepository.RemoveAsync(id, CancellationToken.None);

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
            await UnitOfWork.ApplicationUserRepository.DeleteAsync(id, CancellationToken.None);

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
            await UnitOfWork.ApplicationUserRepository.RestoreAsync(id, CancellationToken.None);

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
            await UnitOfWork.ApplicationUserRepository.LockAsync(id, lockoutReason, CancellationToken.None);

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
            await UnitOfWork.ApplicationUserRepository.UnLockAsync(id, CancellationToken.None);

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
            await UnitOfWork.ApplicationUserRepository.ConfirmPhoneAsync(id, CancellationToken.None);

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
            await UnitOfWork.ApplicationUserRepository.UnConfirmPhoneAsync(id, CancellationToken.None);

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
            await UnitOfWork.ApplicationUserRepository.ConfirmEmailAsync(id, CancellationToken.None);

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
            await UnitOfWork.ApplicationUserRepository.UnConfirmEmailAsync(id, CancellationToken.None);

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
