using Common.Utilities.SweetAlert;
using Newtonsoft.Json;

namespace Admin.MVC.Controllers;

public class BaseController : Controller
{
    #region ( Sweet Alert )
    #region ( Success )
    protected void SuccessAlert()
    {
        var model = JsonConvert.SerializeObject(JsonAlertType.Success());

        HttpContext.Response.Cookies.Append("SystemAlert", model);
    }

    protected void SuccessAlert(string message)
    {
        var model = JsonConvert.SerializeObject(JsonAlertType.Success(message));

        HttpContext.Response.Cookies.Append("SystemAlert", model);
    }
    #endregion

    #region ( Info )
    protected void InfoAlert()
    {
        var model = JsonConvert.SerializeObject(JsonAlertType.Info());

        HttpContext.Response.Cookies.Append("SystemAlert", model);
    }
    protected void InfoAlert(string message)
    {
        var model = JsonConvert.SerializeObject(JsonAlertType.Info(message));

        HttpContext.Response.Cookies.Append("SystemAlert", model);
    }
    #endregion

    #region ( Error )
    protected void ErrorAlert()
    {
        var model = JsonConvert.SerializeObject(JsonAlertType.Error());

        HttpContext.Response.Cookies.Append("SystemAlert", model);
    }
    protected void ErrorAlert(string message)
    {
        var model = JsonConvert.SerializeObject(JsonAlertType.Error(message));

        HttpContext.Response.Cookies.Append("SystemAlert", model);
    }
    #endregion
    #endregion
}