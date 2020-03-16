using System.ComponentModel;

namespace PortKonnect.UserAccessManagement.Domain.Enums
{
    public enum VOADocTypesEnum
    {
        [Description("Address Proof")]
        AddressProof,

        [Description("Agreement With Agency")]
        AgreementWithAgency,

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

        [Description("Valid M.L.O Licence With Customs At Vijayawada")]
        ValidMLOLicenceWithCustomsAtVijayawada,

        [Description("Valid Steamer Agency Licence With Jurisdictional Customs")]
        ValidSteamerAgencyLicenceWithCustoms,
         

    }
}
