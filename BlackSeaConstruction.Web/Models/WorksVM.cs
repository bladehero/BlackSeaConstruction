using BlackSeaConstruction.BusinessLogicLayer.ViewModels.Projects;
using System.Collections.Generic;

namespace BlackSeaConstruction.Web.Models
{
    public class WorksVM
    {
        public IEnumerable<ProjectVM> Projects { get; set; }
        public ProjectVM Project { get; set; }
    }
}
