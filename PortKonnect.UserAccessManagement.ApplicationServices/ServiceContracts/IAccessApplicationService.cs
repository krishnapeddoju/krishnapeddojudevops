using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortKonnect.UserAccessManagement.ApplicationServices;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.ApplicationServices
{
    public interface IAccessApplicationService
    {
        bool AuthenticateUser(int applicationId,string userName, string password);
        void RegisterPartnerInPortKonnect(string partnerName, string partnerType);
        void RegisterPartnerInSubscribedApplication(int partnerId, int applicationId, string subscriberId);
        ICollection<AppMemberDTO> GetMembersOfApplication(int applicationId, string subscriberId);
        ICollection<AppMemberDTO> GetMembersOfApplication(int applicationId, string subscriberId, string partnerTypeCodeOfMember);
        //TODO:  Add other parameters of user like emailid etc.  Or keep all thse in a DTO and pass to this function.
        void RegisterUser(string userName, string password, int partnerId); //If Partner is a member in any application, user will automatically can have access to that application.
        void ChangePassword(string userId, string password);
        void ResetPassword(string userId);
    }
}

