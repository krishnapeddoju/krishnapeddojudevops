//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using PortKonnect.UserAccessManagement.Data;
//using PortKonnect.UserAccessManagement.Domain;
//using PortKonnect.UserAccessManagement.Domain.DTOS;
//using PortKonnect.UserAccessManagement.Domain.Repositories;
//using PortKonnect.UserAccessManagement.Repositories;
//using PortKonnect.UserAccessManagement.Web.MockServices.Interfaces;

//namespace PortKonnect.UserAccessManagement.Web.MockServices
//{
//    public class MockUserService : IMockUserService
//    {
//        private readonly IUserRepository _userRepository;

//        public MockUserService(IUserContext userContext, IUserRepository userRepository)
//        {
//            _userRepository = userRepository;
//        }

//        public List<UserDTO> GetUsersUnderTO()
//        {
//            List<UserDTO> userDtos = new List<UserDTO>();
//            //{
//            //    new UserDTO()
//            //    {
//            //        UserId = "",
//            //        UserName = "",
//            //        Password = "",
//            //        PartnerId = "",
//            //        RememberMe = true,
//            //        ReturnUrl = "",
//            //        EmailId = "",
//            //        ContactNumber = "",
//            //        AddressDTO = new AddressDTO()
//            //        {
                        
//            //        },
//            //        UserRoles = new List<UserRole>()
//            //        {
//            //            new UserRole()
//            //            {
                            
//            //            }
//            //        },
//            //        UserPorts = new List<UserPort>()
//            //        {
//            //            new UserPort()
//            //            {
    
//            //            }
//            //        }
//            //    }
//            //};
//            return userDtos;
//        }
//    }
//}