using System.ComponentModel;

namespace PortKonnect.UserAccessManagement.Domain.Enums
{
    public enum DocumentTypes
    {
        [Description("Address Proof")]
        AddressProof,

        [Description("Agreement With Agency")]
        AgreementWithAgency,

        [Description("Certificate Of Incorporation (for Companies, LLP, Trusts)")]
        CertificateOfIncorporationforCompaniesLLPTrusts,

        [Description("CFS Licence Copy")]
        CFSLicenceCopy,

        [Description("CHA/MTO (For CHA/FF) Licence Registration With Krishnapatnam Port")]
        CHAMTOForCHAFFLicenceRegistrationWithKrishnapatnamPort,

        [Description("Establishment Registration Certificate")]
        EstablishmentRegistrationCertificate,

        [Description("IICL Copy")]
        IICLCopy,

        [Description("Licence Copy From The Jurisdictional Customs Authority")]
        LicenceCopyFromtheJurisdictionalCustomsAuthority,

        [Description("Memorandum And Article Of Association")]
        MemorandumAndArticleOfAssociation,

        [Description("PAN Card (For Entity/Organization)")]
        PANCardForEntityOrganization,

        [Description("PAN Card (For Individual)")]
        PANCardForIndividual,

        [Description("GST/Service Tax/VAT Registration Certificate")]
        ServiceTaxVATRegistrationCertificate,

        [Description("Shipper Authorization Letter")]
        ShipperAuthorizationLetter,

        [Description("Shops & Establishment Registration Certificate")]
        ShopsEstablishmentRegnCertificate,

        [Description("Valid Customs Continuity Bond")]
        ValidCustomsContinuityBond,

        [Description("Valid M.L.O Licence With Customs At Vijayawada")]
        ValidMLOLicenceWithCustomsAtVijayawada,

        [Description("Valid Steamer Agency Licence With Customs")]
        ValidSteamerAgencyLicenceWithCustoms,
              
        [Description("Valid Steamer Agency Licence With Jurisdictional Customs")]
        ValidSteamerAgencyLicenceWithJurisdictionalCustoms,

    }
}
