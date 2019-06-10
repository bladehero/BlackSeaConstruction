using BlackSeaConstruction.BusinessLogicLayer.ViewModels;
using BlackSeaConstruction.BusinessLogicLayer.ViewModels.Messages;
using System.Collections.Generic;

namespace BlackSeaConstruction.Web.Areas.Admin.Models
{
    public class MessagesVM
    {
        public IEnumerable<MessageVM> Messages { get; set; }
        public PageVM Pages { get; set; }
        public bool WithDeleted { get; set; }
    }
}
