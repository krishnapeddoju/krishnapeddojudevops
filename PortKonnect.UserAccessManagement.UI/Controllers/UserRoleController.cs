using PortKonnect.Common.Enums;
using System.Web.Mvc;

namespace PortKonnect.UserAccessManagement.UI
{
    [Authorize]
    public class UserRoleController : PortKonnectBaseController
    {

        [Route("UserRoles")]
        public ActionResult UserRoles()
        {
            if (CheckIsFirstTimeLogin())
            {
                if (GetPrivilegesFor(AppEntityIds.eGateUserRole.ToString(), AppEntityCodes.eGateUserRoleView.ToString()))//TODO: Need to maintain EntityFunction as ENum
                    return View("UserRoles", privilege);
                else
                    return View("NotFound");
            }
            else
                return RedirectToAction("ChangePasswordAccount", "Account", new { isFirstTimeLogin = "Y" });
        }
    }
}