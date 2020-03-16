using System.Web.Mvc;
using System.Security.Authentication;
using PortKonnect.Common.Contracts;

namespace PortKonnect.UserAccessManagement.UI
{
    [Authorize]
    public class SuperCategoryController : PortKonnectBaseController
    {
        [Route("SuperCategories")]
        public ActionResult SuperCategories()
        {            
            //TODO:A Write a anonymous fuction in Base class and include try catch logic there.
            try
            {
                if (CheckIsFirstTimeLogin())
                {         
                    if (GetPrivilegesFor(CargoAppEntityCodes.cargoSuperCategory.ToString(), CargoAppEntityCodes.cargoSuperCategoryView.ToString()))//TODO: Need to maintain EntityFunction as ENum
                        return View("SuperCategories", privilege);
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

        [Route("SuperCategory")]
        public ActionResult SuperCategory()
        {            
            if (CheckIsFirstTimeLogin())
            {
                if (GetPrivilegesFor(CargoAppEntityCodes.cargoSuperCategory.ToString(), CargoAppEntityCodes.cargoSuperCategoryAdd.ToString()))
                    return View("SuperCategory", privilege);
                else
                    return View("NotFound");
            }
            else
                return RedirectToAction("ChangePasswordAccount", "Account", new { isFirstTimeLogin = "Y" });

        }

        [Route("SuperCategory/{supCatId}")]
        public ActionResult SuperCategory(string supCatId)
        {            
            if (CheckIsFirstTimeLogin())
            {
                if (GetPrivilegesFor(CargoAppEntityCodes.cargoSuperCategory.ToString(), CargoAppEntityCodes.cargoSuperCategoryEdit.ToString()))
                {
                    ViewBag.supCatId = supCatId;
                    return View("SuperCategory");
                }
                else
                    return View("NotFound");
            }
            else
                return RedirectToAction("ChangePasswordAccount", "Account", new { isFirstTimeLogin = "Y" });

        }

        [Route("SuperCategoryView/{supCatId}")]
        public ActionResult SuperCategoryView(string supCatId)
        {           

            if (CheckIsFirstTimeLogin())
            {
                if (GetPrivilegesFor(CargoAppEntityCodes.cargoSuperCategory.ToString(), CargoAppEntityCodes.cargoSuperCategoryView.ToString()))
                {
                    ViewBag.supCatId = supCatId;
                    return View("SuperCategoryView");
                }
                else
                    return View("NotFound");
            }
            else
                return RedirectToAction("ChangePasswordAccount", "Account", new { isFirstTimeLogin = "Y" });

        }

    }
}