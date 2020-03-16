using PortKonnect.Common.Enums;
using System.Web.Mvc;


namespace PortKonnect.UserAccessManagement.UI
{
    [Authorize]
    public class UserController : PortKonnectBaseController
    {
        [Route("Users")]
        public ActionResult Users()
        {
            if (CheckIsFirstTimeLogin())
            {
                if (GetPrivilegesFor(AppEntityIds.eGateUser.ToString(), AppEntityCodes.eGateUserView.ToString()))//TODO: Need to maintain EntityFunction as ENum
                    return View("Users", privilege);
                else
                    return View("NotFound");
            }
            else
                return RedirectToAction("ChangePasswordAccount", "Account", new { isFirstTimeLogin = "Y" });
        }

        [Route("User")]
        public ActionResult User()
        {
            if (CheckIsFirstTimeLogin())
            {
                if (GetPrivilegesFor(AppEntityIds.eGateUser.ToString(), AppEntityCodes.eGateUserAdd.ToString()))//TODO: Need to maintain EntityFunction as ENum
                    return View("User", privilege);
                else
                    return View("NotFound");
            }
            else
                return RedirectToAction("ChangePasswordAccount", "Account", new { isFirstTimeLogin = "Y" });

        }

       

		[Route("User/{userId}/{path}")]
		public ActionResult User(string userId, string path)
		{
			if (CheckIsFirstTimeLogin())
			{
				ViewBag.UserId = userId;
				ViewBag.Path = path;
				if (GetPrivilegesFor(AppEntityIds.eGateUser.ToString(), AppEntityCodes.eGateUserEdit.ToString()))//TODO: Need to maintain EntityFunction as ENum
					return View("User", privilege);
				else
					return View("NotFound");
			}
			else
                return RedirectToAction("ChangePasswordAccount", "Account", new { isFirstTimeLogin = "Y" });


		}

        [Route("UserView/{userId}")]
        public ActionResult UserView(string userId)
        {
            if (CheckIsFirstTimeLogin())
            {
                ViewBag.UserId = userId;
                if (GetPrivilegesFor(AppEntityIds.eGateUser.ToString(), AppEntityCodes.eGateUserView.ToString()))//TODO: Need to maintain EntityFunction as ENum
                    return View("UserView", privilege);
                else
                    return View("NotFound");
            }
            else
                return RedirectToAction("ChangePasswordAccount", "Account", new { isFirstTimeLogin = "Y" });

        }
    }
}