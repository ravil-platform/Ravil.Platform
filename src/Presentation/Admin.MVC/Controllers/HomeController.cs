using Domain.Entities.Histories.Enums;
using Domain.Entities.Histories;

namespace Admin.MVC.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }



     
    }
}
