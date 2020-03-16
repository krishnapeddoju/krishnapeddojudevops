using System.Web.Mvc;
using System.Security.Authentication;
using PortKonnect.Common.Contracts;

namespace PortKonnect.UserAccessManagement.UI
{
    [Authorize]
    public class EmployeeController : PortKonnectBaseController
    {
        [Route("Employees")]
        public ActionResult Employees()
        {
            //TODO:A Write a anonymous fuction in Base class and include try catch logic there.
            try
            {
                if (CheckIsFirstTimeLogin())
                {            
                    if (GetPrivilegesFor(CargoAppEntityCodes.cargoEmployee.ToString(), CargoAppEntityCodes.cargoEmployeeView.ToString()))//TODO: Need to maintain EntityFunction as ENum
                        return View("Employees", privilege);
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

        [Route("Employee")]
        public ActionResult Employee()
        {            
            if (CheckIsFirstTimeLogin())
            {
                if (GetPrivilegesFor(CargoAppEntityCodes.cargoEmployee.ToString(), CargoAppEntityCodes.cargoEmployeeAdd.ToString()))
                    return View("Employee", privilege);
                else
                    return View("NotFound");
            }
            else
                return RedirectToAction("ChangePasswordAccount", "Account", new { isFirstTimeLogin = "Y" });

        }

        [Route("Employee/{empId}")]
        public ActionResult Employee(string empId)
        {         
            if (CheckIsFirstTimeLogin())
            {
                if (GetPrivilegesFor(CargoAppEntityCodes.cargoEmployee.ToString(), CargoAppEntityCodes.cargoEmployeeEdit.ToString()))
                {
                    ViewBag.empId = empId;
                    return View("Employee");
                }
                else
                    return View("NotFound");
            }
            else
                return RedirectToAction("ChangePasswordAccount", "Account", new { isFirstTimeLogin = "Y" });

        }

        [Route("EmployeeView/{empId}")]
        public ActionResult EmployeeView(string empId)
        {           

            if (CheckIsFirstTimeLogin())
            {
                if (GetPrivilegesFor(CargoAppEntityCodes.cargoEmployee.ToString(), CargoAppEntityCodes.cargoEmployeeView.ToString()))
                {
                    ViewBag.empId = empId;
                    return View("EmployeeView");
                }
                else
                    return View("NotFound");
            }
            else
                return RedirectToAction("ChangePasswordAccount", "Account", new { isFirstTimeLogin = "Y" });
        }

    }
}