using PortKonnect.Common.Contracts;
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
                if (GetPrivilegesFor(CargoAppEntityCodes.cargoRole.ToString(), CargoAppEntityCodes.cargoRoleView.ToString()))
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
                if (GetPrivilegesFor(CargoAppEntityCodes.cargoRole.ToString(), CargoAppEntityCodes.cargoRoleAdd.ToString()))
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
                if (GetPrivilegesFor(CargoAppEntityCodes.cargoRole.ToString(), CargoAppEntityCodes.cargoRoleEdit.ToString()))
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
                if (GetPrivilegesFor(CargoAppEntityCodes.cargoRole.ToString(), CargoAppEntityCodes.cargoRoleView.ToString()))
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