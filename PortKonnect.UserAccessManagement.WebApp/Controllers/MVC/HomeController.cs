using System.Web.Mvc;
using PortKonnect.UserAccessManagement.UI;

namespace PortKonnect.UserAccessManagement.WebApp.Controllers.MVC
{
    [Authorize]
    public class HomeController : PortKonnectBaseController
    {
        //[Route("Home")]

        [Route("~/", Name = "default")] 
        public ActionResult Index()
        {
            if (CheckIsFirstTimeLogin())
            {
                return View("Index");
            }
            else
                return RedirectToAction("ChangePasswordAccount", "Account", new { IsFirstTimeLogin = "Y" });
        }

        [Route("Notifications")]

        public ActionResult Notifications()
        {
            return View("Notifications");
        }

    }
}