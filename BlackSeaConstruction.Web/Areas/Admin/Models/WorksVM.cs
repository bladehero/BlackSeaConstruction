using BlackSeaConstruction.BusinessLogicLayer.ViewModels;
using BlackSeaConstruction.BusinessLogicLayer.ViewModels.Projects;
using System.Collections.Generic;

namespace BlackSeaConstruction.Web.Areas.Admin.Models
{
    public class WorksVM
    {
        public IEnumerable<ProjectVM> Projects { get; set; }
        public PageVM Pages { get; set; }
        public bool WithDeleted { get; set; }
    }
}
