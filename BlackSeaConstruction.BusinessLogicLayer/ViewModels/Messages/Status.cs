using System.ComponentModel;

namespace BlackSeaConstruction.BusinessLogicLayer.ViewModels.Messages
{
    public enum Status
    {
        [Description("Pending")]
        P,
        [Description("Completed")]
        C,
        [Description("Rejected")]
        R
    }
}
