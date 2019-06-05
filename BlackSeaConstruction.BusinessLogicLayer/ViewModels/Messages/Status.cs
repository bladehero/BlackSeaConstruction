using System.ComponentModel;

namespace BlackSeaConstruction.BusinessLogicLayer.ViewModels.Messages
{
    public enum Status
    {
        [Description("Completed")]
        C,
        [Description("Pending")]
        P,
        [Description("Rejected")]
        R
    }
}
