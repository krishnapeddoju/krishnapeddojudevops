using PortKonnect.Common.Enums;
using System.Web.Mvc;

namespace PortKonnect.UserAccessManagement.UI
{
   [Authorize]
    public class RoleController:PortKonnectBaseController
    {
        [Route("Roles")]
        public ActionResult Roles()
        {
            if (CheckIsFirstTimeLogin())
            {
                if (GetPrivilegesFor(AppEntityIds.eGateRole.ToString(), AppEntityCodes.eGateRoleView.ToString()))
                    return View("Roles", privilege);
                else
                    return View("NotFound");
            }
             else
                return RedirectToAction("ChangePasswordAccount", "Account", new { isFirstTimeLogin = "Y" });
            
           
        }

        [Route("Role")]
        public ActionResult Role()
        {
            if (CheckIsFirstTimeLogin())
            {
                if (GetPrivilegesFor(AppEntityIds.eGateRole.ToString(), AppEntityCodes.eGateRoleAdd.ToString()))
                    return View("Role", privilege);
                else
                    return View("NotFound");
            }
            else
                return RedirectToAction("ChangePasswordAccount", "Account", new { isFirstTimeLogin = "Y" });
            
            //return View("Role");
        }

        [Route("Role/{roleId}")]
        public ActionResult Role(string roleId)
        {
            if (CheckIsFirstTimeLogin())
            {
                if (GetPrivilegesFor(AppEntityIds.eGateRole.ToString(), AppEntityCodes.eGateRoleEdit.ToString()))
                {
                    ViewBag.roleId = roleId;
                    return View("Role");
                }
                else
                    return View("NotFound");
            }
            else
                return RedirectToAction("ChangePasswordAccount", "Account", new { isFirstTimeLogin = "Y" });
            

          
        }

        [Route("RoleView/{roleId}")]
        public ActionResult UserView(string roleId)
        {

            if (CheckIsFirstTimeLogin())
            {
                if (GetPrivilegesFor(AppEntityIds.eGateRole.ToString(), AppEntityCodes.eGateRoleView.ToString()))
                {
                    ViewBag.roleId = roleId;
                    return View("RoleView");
                }
                else
                    return View("NotFound");
            }
            else
                return RedirectToAction("ChangePasswordAccount", "Account", new { isFirstTimeLogin = "Y" });
            
           
        }

    }
}