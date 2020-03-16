using System.ComponentModel;

namespace PortKonnect.UserAccessManagement.Domain.Enums
{
    public enum PartnerType
    {
        [Description("Super Admin")]
        SuperAdmin,

        [Description("Port Authority")]
        PortAuthority,

        [Description("Terminal Operator")]
        TerminalOperator,

        [Description("Vessel Agent")]
        VesselAgent,

        [Description("Vessel Operating Agent")]
        VesselOperatingAgent,

        [Description("Consortium Partner")]
        ConsortiumPartner,

        [Description("Container Operator Agent")]
        ContainerOperatorAgent,

        [Description("Custom House Agent")]
        CustomHouseAgent,

        [Description("Container Freight Station")]
        ContainerFreightStation,

        [Description("Customs")]
        Customs,

        [Description("Security")]
        Security,

        [Description("Container Train Operator")]
        ContainerTrainOperator,

        [Description("Inland Container Depot")]
        InlandContainerDepot,

        [Description("Gate Operator")]
        GateOperator,

        [Description("Finance")]
        Finance,

        [Description("Maintenance and Repair")]
        MandR
    }
}
