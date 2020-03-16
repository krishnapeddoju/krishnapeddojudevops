using System.Web.Mvc;
using PortKonnect.Common.Enums;
using System.Security.Authentication;

namespace PortKonnect.UserAccessManagement.UI
{
    [Authorize]
    public class PartnerRegistrationController : PortKonnectBaseController
    {
        [Route("PendingPartnerRegistrations")]
        public ActionResult PendingPartnerRegistrations()
        {
            return View("PendingPartnerRegistrations");

        }

        [Route("PartnerRegistration")]
        public ActionResult PartnerRegistration()
        { 
            return View("PartnerRegistration");
        }

        [Route("PendingPartnerRegistrationView/{RequisitionNo}")]
        public ActionResult PendingPartnerRegistrationView(string RequisitionNo)
        {
            ViewBag.RequisitionNo = RequisitionNo;
            return View("PartnerRegistrationView");
        }
    }
}