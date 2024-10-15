using AutoMapper;
using Domain.Entities.User;
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
        public IActionResult Create(CreateUserViewModel createUserViewModel)
        {
            if (!ModelState.IsValid)
            {
                ErrorAlert();

                return RedirectToAction();
            }

            var user = Mapper.Map<ApplicationUser>(createUserViewModel);

            var result =  UnitOfWork.ApplicationUserRepository.InsertAsync(user);

            try
            {
                UnitOfWork.SaveAsync();

                SuccessAlert();
            }
            catch (Exception e)
            {
                ErrorAlert(e.Message);
            }

            return RedirectToAction("Index");
        }
        #endregion
    }
}
