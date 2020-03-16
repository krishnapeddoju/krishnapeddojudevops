using System.ComponentModel;

namespace PortKonnect.UserAccessManagement.Domain.Enums
{
    public enum CHADocTypesEnum
    {
        [Description("Address Proof")]
        AddressProof,

        [Description("Certificate Of Incorporation (for Companies, LLP, Trusts)")]
        CertificateOfIncorporationforCompaniesLLPTrusts,

        [Description("CHA/MTO (For CHA/FF) Licence Registration With Krishnapatnam Port")]
        CHAMTOForCHAFFLicenceRegistrationWithKrishnapatnamPort,

        [Description("Memorandum And Article Of Association")]
        MemorandumAndArticleOfAssociation,

        [Description("PAN Card (For Entity/Organization/Individual)")]
        PANCardForEntityOrganizationIndividual,

        [Description("GST/Service Tax/VAT Registration Certificate")]
        ServiceTaxVATRegistrationCertificate,

        [Description("Shipper Authorization Letter")]
        ShipperAuthorizationLetter,

        [Description("TAN Card (For Entity/Organization/Individual)")]
        TANCardForEntityOrganizationIndividual,
      
    }
}
