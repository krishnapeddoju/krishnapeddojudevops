using System.Web.Mvc;
using System.Security.Authentication;
using PortKonnect.Common.Contracts;

namespace PortKonnect.UserAccessManagement.UI
{
    [Authorize]
    public class SubCategoryController : PortKonnectBaseController
    {
        [Route("SubCategories")]
        public ActionResult SubCategories()
        {
            //TODO:A Write a anonymous fuction in Base class and include try catch logic there.
            try
            {
                if (CheckIsFirstTimeLogin())
                {
                    if (GetPrivilegesFor(CargoAppEntityCodes.cargoSubCategory.ToString(), CargoAppEntityCodes.cargoSubCategoryView.ToString()))//TODO: Need to maintain EntityFunction as ENum
                        return View("SubCategories", privilege);
                    else
                        return View("NotFound");
                }
                else
                    return RedirectToAction("ChangePasswordAccount", "Account", new { isFirstTimeLogin = "Y" });
            }
            catch (AuthenticationException ex)
            {
                //TODO:A: If it is Ok to redirect to Logoff. where we clean up all cookies etc.
                return Redirect("/Logout");
            }

        }     

    }
}