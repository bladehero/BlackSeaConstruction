using BlackSeaConstruction.BusinessLogicLayer.ViewModels.Services;
using System.Collections.Generic;

namespace BlackSeaConstruction.Web.Models
{
    public class ServicesVM
    {
        public IEnumerable<ServiceTypeVM> Services { get; set; }
        public ServiceVM Service { get; set; }
    }
}
