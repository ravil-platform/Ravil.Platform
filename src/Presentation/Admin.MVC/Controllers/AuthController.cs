namespace Admin.MVC.Controllers
{
    public class AuthController(
        UserManager<ApplicationUser> userManager,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        SignInManager<ApplicationUser> signInManager)
        : Controller
    {
        #region ( DI )
        protected UserManager<ApplicationUser> UserManager { get; } = userManager;
        protected SignInManager<ApplicationUser> SignInManager { get; } = signInManager;
        protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
        protected IMapper Mapper { get; } = mapper;
        #endregion

        #region ( Login )
        [HttpGet("/account/sign-in")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("/account/sign-in")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                #region ( Validate Security Stamp )

                var user = await UserManager.FindByNameAsync(model.PhoneNumber!);
                if (user != null)
                {
                    try
                    {
                        var userSecurityStamp = await UserManager.GetSecurityStampAsync(user);
                        var validSecurityStamp = await SignInManager.ValidateSecurityStampAsync(user, userSecurityStamp);

                        if (string.IsNullOrWhiteSpace(userSecurityStamp) || !validSecurityStamp)
                            await UserManager.UpdateSecurityStampAsync(user);
                    }
                    catch (InvalidOperationException)
                    {
                        await UserManager.UpdateSecurityStampAsync(user);
                    }
                }

                #endregion

                var result = await SignInManager.PasswordSignInAsync(model.PhoneNumber!, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    SuccessAlert("خوش آمدید!");

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
            return View(model);
        }
        #endregion

        #region ( Log out )
        [HttpGet("/account/sign-out")]
        public async Task<IActionResult> Logout()
        {
            await SignInManager.SignOutAsync();

            SuccessAlert("به امید دیدار مجدد!");

            return RedirectToAction("Login");
        }
        #endregion

        #region ( AccessDenied )

        [HttpGet("/account/access-denied")]
        public IActionResult AccessDenied()
        {
            return View();
        }
        #endregion

        #region ( Success Alert )
        protected void SuccessAlert(string message)
        {
            var model = JsonConvert.SerializeObject(JsonAlertType.Success(message));

            HttpContext.Response.Cookies.Append("SystemAlert", model);
        }
        #endregion
    }
}