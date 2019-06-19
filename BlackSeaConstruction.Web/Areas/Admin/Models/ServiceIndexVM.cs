using BlackSeaConstruction.BusinessLogicLayer.ViewModels;
using BlackSeaConstruction.BusinessLogicLayer.ViewModels.Services;
using System.Collections.Generic;

namespace BlackSeaConstruction.Web.Areas.Admin.Models
{
    public class ServiceIndexVM
    {
        public IEnumerable<ServiceVM> Services { get; set; }
        public IEnumerable<ServiceTypeVM> ServiceTypes { get; set; }
        public PageVM Pages { get; set; }
        public bool WithDeleted { get; set; }
    }
}
