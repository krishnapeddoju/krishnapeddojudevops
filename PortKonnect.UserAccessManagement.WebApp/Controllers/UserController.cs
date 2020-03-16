using PortKonnect.Common.Contracts;
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
                if (GetPrivilegesFor(CargoAppEntityCodes.cargoUser.ToString(), CargoAppEntityCodes.cargoUserView.ToString()))//TODO: Need to maintain EntityFunction as ENum
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
                if (GetPrivilegesFor(CargoAppEntityCodes.cargoUser.ToString(), CargoAppEntityCodes.cargoUserAdd.ToString()))//TODO: Need to maintain EntityFunction as ENum
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
                var userDto = GetDetails(userId);
                if (userDto != null)
                {
                    //SuperAdmin user record edit restriction
                    if (userDto.UserName.ToUpper() == "ADMIN" && path.ToUpper() == "EDIT")
                    {
                        return View("NotFound");
                    }

                    ViewBag.UserId = userDto.UserId;
                    ViewBag.Path = path;
                    if (GetPrivilegesFor(CargoAppEntityCodes.cargoUser.ToString(), CargoAppEntityCodes.cargoUserEdit.ToString()))
                        return View("User", privilege);
                    else
                        return View("NotFound");
                }

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
                if (GetPrivilegesFor(CargoAppEntityCodes.cargoUser.ToString(), CargoAppEntityCodes.cargoUserView.ToString()))//TODO: Need to maintain EntityFunction as ENum
                    return View("UserView", privilege);
                else
                    return View("NotFound");
            }
            else
                return RedirectToAction("ChangePasswordAccount", "Account", new { isFirstTimeLogin = "Y" });

        }
    }
}