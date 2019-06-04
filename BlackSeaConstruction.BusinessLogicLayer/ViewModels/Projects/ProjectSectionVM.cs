using System;
using System.Collections.Generic;
using System.Text;

namespace BlackSeaConstruction.BusinessLogicLayer.ViewModels.Projects
{
    public class ProjectSectionVM
    {
        public int Id { get; set; }
        public string SectionName { get; set; }
        public string ProjectName { get; set; }
        public IEnumerable<string> Images { get; set; }
    }
}
