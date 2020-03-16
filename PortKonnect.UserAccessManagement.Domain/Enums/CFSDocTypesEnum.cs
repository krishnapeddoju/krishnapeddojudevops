using System.ComponentModel;

namespace PortKonnect.UserAccessManagement.Domain.Enums
{
    public enum CFSDocTypesEnum
    {
        [Description("Address Proof")]
        AddressProof,
        [Description("CFS Licence Copy")]
        CFSLicenceCopy,
        [Description("Establishment Registration Certificate")]
        EstablishmentRegistrationCertificate,
        [Description("PAN/TAN Card (For Entity/Organization)")]
        PANCardForEntityOrganization,
        [Description("GST/Service Tax/VAT Registration Certificate")]
        ServiceTaxVATRegistrationCertificate,       
    }
}
