using System.ComponentModel;

namespace PortKonnect.UserAccessManagement.Domain.Enums
{
    public enum PartnerType
    {
        [Description("Consortium Partner")]
        ConsortiumPartner,

        [Description("Container Freight Station")]
        ContainerFreightStation,

        [Description("Container Train Operator")]
        ContainerTrainOperator,

        [Description("Container Operator Agent")]
        ContainerOperatorAgent,

        [Description("Customs")]
        Customs,

        [Description("Custom House Agent")]
        CustomHouseAgent,
     

        [Description("Finance")]
        Finance,

        [Description("Gate Operator")]
        GateOperator,

        [Description("Inland Container Depot")]
        InlandContainerDepot,

        [Description("Maintenance and Repair")]
        MandR,

        [Description("Port Authority")]
        PortAuthority,

        [Description("Security")]
        Security,

        [Description("Super Admin")]
        SuperAdmin,

        [Description("Terminal Operator")]
        TerminalOperator,

        [Description("Vessel Agent")]
        VesselAgent,

        [Description("Vessel Operating Agent")]
        VesselOperatingAgent,

    }
}
