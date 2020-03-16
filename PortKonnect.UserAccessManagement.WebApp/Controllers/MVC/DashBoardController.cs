using System.Security.Claims;
using System.Web.Mvc;
using System.Web;
using System.Web.Security;
using PortKonnect.Common.Enums;
using PortKonnect.UserAccessManagement.UI;

namespace PortKonnect.UserAccessManagement.WebApp.Controllers.MVC
{
    public class DashBoardController : PortKonnectBaseController
    {
        [Route("DashBoard")]
        public ActionResult Index()
        {
            return View("Index");
        }
    }
}