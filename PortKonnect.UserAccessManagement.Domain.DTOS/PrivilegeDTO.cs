using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortKonnect.UserAccessManagement.Domain.DTOS
{
    public class PrivilegeDTO
    {
        public string Privileges { get; set; }

        public bool HasPrivilege(string privilegeCode)
        {
            return Privileges.Contains(privilegeCode);
        }
        
        //TODO: Need to verify the use of below methods
        public bool HasAddPrivilege
        {
            get
            {
                return HasPrivilege("ADD");
            }
        }
        public bool HasViewPrivilege
        {
            get
            {
                return HasPrivilege("VIEW");
            }
        }
        public bool HasDeletePrivilege
        {
            get
            {
                return HasPrivilege("DEL");
            }
        }
        public bool HasEditPrivilege
        {
            get
            {
                return HasPrivilege("EDIT");
            }
        }
    }
}
