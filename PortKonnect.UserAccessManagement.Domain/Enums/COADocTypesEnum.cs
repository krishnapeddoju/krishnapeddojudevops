using System.ComponentModel;

namespace PortKonnect.UserAccessManagement.Domain.Enums
{
    public enum COADocTypesEnum
    {
        [Description("Address Proof")]
        AddressProof,

        [Description("Certificate Of Incorporation (for Companies, LLP, Trusts)")]
        CertificateOfIncorporationforCompaniesLLPTrusts,


        [Description("Establishment Registration Certificate")]
        EstablishmentRegistrationCertificate,

        [Description("Licence Copy From The Jurisdictional Customs Authority")]
        LicenceCopyFromtheJurisdictionalCustomsAuthority,

        [Description("Memorandum And Article Of Association")]
        MemorandumAndArticleOfAssociation,

        [Description("PAN Card (For Entity/Organization)")]
        PANCardForEntityOrganization,

        [Description("GST/Service Tax/VAT Registration Certificate")]
        ServiceTaxVATRegistrationCertificate,

        [Description("TAN Card (For Entity/Organization)")]
        TANCardForEntityOrganization,

        [Description("Valid Agency Agreement")]
        AgreementWithAgency,

        [Description("Valid Customs Continuity Bond")]
        ValidCustomsContinuityBond,

        [Description("Valid Steamer Agency Licence With Jurisdictional Customs")]
        ValidSteamerAgencyLicenceWithCustoms,

        
       

       
    }
}
