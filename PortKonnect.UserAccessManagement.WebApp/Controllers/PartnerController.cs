using System.Web.Mvc;
using PortKonnect.Common.Enums;
using System.Security.Authentication;
using PortKonnect.Common.Contracts;

namespace PortKonnect.UserAccessManagement.UI
{
   [Authorize]
    public class PartnerController : PortKonnectBaseController
    {
        [Route("Partners")]
        public ActionResult Partners()
        {
            //TODO:A Write a anonymous fuction in Base class and include try catch logic there.
            try
            {
                if (CheckIsFirstTimeLogin())
                {
                    if (GetPrivilegesFor(CargoAppEntityCodes.cargoPartner.ToString(), CargoAppEntityCodes.cargoPartnerView.ToString()))//TODO: Need to maintain EntityFunction as ENum
                        return View("Partners", privilege);
                    else
                        return View("NotFound");
                }
                else
                    return RedirectToAction("ChangePasswordAccount", "Account", new { isFirstTimeLogin = "Y" });
            }
            catch (AuthenticationException ex)
            {
                //TODO:A: If it is Ok to redirect to Logoff. where we clean up all cookies etc.
                return Redirect ("/Logout");
            }

        }


        [Route("Partner")]
        public ActionResult Partner()
        {
            if (CheckIsFirstTimeLogin())
            {
                if (GetPrivilegesFor(CargoAppEntityCodes.cargoPartner.ToString(), CargoAppEntityCodes.cargoPartnerAdd.ToString()))//TODO: Need to maintain EntityFunction as ENum
                    return View("Partner", privilege);
                else
                {
                    return View("NotFound");
                }
            }
            else
                return RedirectToAction("ChangePasswordAccount", "Account", new { isFirstTimeLogin = "Y" });
        }

        
		[Route("Partner/{PartnerId}/{path}")]
		public ActionResult Partner(string PartnerId, string path)
		{
			if (CheckIsFirstTimeLogin())
			{
				ViewBag.PartnerId = PartnerId;
				ViewBag.Path = path;
				if (GetPrivilegesFor(CargoAppEntityCodes.cargoPartner.ToString(), CargoAppEntityCodes.cargoPartnerView.ToString()))//TODO: Need to maintain EntityFunction as ENum
					return View("Partner", privilege);
				else
				{
					return View("NotFound");
				}
			}
			else
                return RedirectToAction("ChangePasswordAccount", "Account", new { isFirstTimeLogin = "Y" });
		}

    }
}