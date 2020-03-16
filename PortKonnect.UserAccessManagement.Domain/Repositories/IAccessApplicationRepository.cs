using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortKonnect.UserAccessManagement.Domain;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.Repositories.Interfaces
{
    public interface IAccessApplicationRepository
    {
        bool AuthenticateUser(int applicationId, string userName, string password);
        void RegisterPartnerInPortKonnect(string partnerName, string partnerType, string partnerCode, Address address);
        void RegisterPartnerInSubscribedApplication(string partnerId, int applicationId, string subscriberId);
        List<AppMemberDTO> GetMembersOfApplication(int applicationId, string subscriberId);
        List<AppMemberDTO> GetMembersOfApplication(int applicationId, string subscriberId, string memberId);
        //TODO:  Add other parameters of user like emailid etc.  Or keep all thse in a DTO and pass to this function.
        void RegisterUser(string userName, string password, int partnerId); //If Partner is a member in any application, user will automatically can have access to that application.
        void ChangePassword(string userId, string password);
        void ResetPassword(string userId);

    }
}
