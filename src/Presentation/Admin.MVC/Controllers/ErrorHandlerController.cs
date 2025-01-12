namespace Admin.MVC.Controllers
{
    public class ErrorHandlerController : Controller
    {
        [Route("/ErrorHandler/{Code}")]
        public IActionResult Index(int Code)
        {
            switch (Code)
            {
                case 404:
                    return View("NotFound");
                case 500:
                    return View("ServerError");

                default:
                    break;
            }

            return View("NotFound");
        }
    }
}
