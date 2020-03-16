using System.ComponentModel;

namespace PortKonnect.UserAccessManagement.Domain.Enums
{
    public enum Status
    {

        [Description("HUF")] 
        HUF,

        [Description("Individual")]
        Individual,


        [Description("Partnership")]
        Partnership,

        [Description("Private Co")]
        PrivateCo,

        [Description("Proprietorship")]
        Proprietorship,

        [Description("Public Co")]
        PublicCo,
      
        [Description("Trust")]
        Trust

       
    }
}
