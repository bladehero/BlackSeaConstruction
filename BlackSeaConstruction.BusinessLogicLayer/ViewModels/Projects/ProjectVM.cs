using System;
using System.Collections.Generic;
using System.Text;

namespace BlackSeaConstruction.BusinessLogicLayer.ViewModels.Projects
{
    public class ProjectVM
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public IEnumerable<ProjectSectionVM> ProjectSections { get; set; }
    }
}
