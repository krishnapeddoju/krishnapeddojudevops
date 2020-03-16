using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using PortKonnect.UserAccessManagement.Data;
using PortKonnect.UserAccessManagement.Domain;
using PortKonnect.UserAccessManagement.Repositories.Interfaces;
using PortKonnect.UserAccessManagement.Domain.DTOS;

namespace PortKonnect.UserAccessManagement.Repositories
{
    public class AccessApplicationRepository : IAccessApplicationRepository
    {

        public AccessApplicationRepository()
        {
        }

        //TODO:To be implemented
        public bool AuthenticateUser(int applicationId, string userName, string password)
        {
            return true;
        }

        //TODO:To be implemented
        public void RegisterPartnerInPortKonnect(string partnerName, string partnerType, string partnerCode, Address address)
        {

            //_unitOfWork.SaveChanges();
        }

        //TODO:To be implemented
        public void RegisterPartnerInSubscribedApplication(string partnerId, int applicationId, string subscriberId)
        {
            //Inserting data into Subscription Application table

            //_unitOfWork.SaveChanges();

        }

        //TODO:To be implemented
        public List<AppMemberDTO> GetMembersOfApplication(int applicationId, string subscriberId)
        {
            return null;
        }

        //TODO:To be implemented
        public List<AppMemberDTO> GetMembersOfApplication(int applicationId, string subscriberId, string memberId)
        {
            return null;
        }

        //TODO:To be implemented
        public void RegisterUser(string userName, string password, int partnerId)
        {

        }

        //TODO:To be implemented
        public void ChangePassword(string userId, string password)
        {
        }

        //TODO:To be implemented
        public void ResetPassword(string userId)
        {
        }


    }
}