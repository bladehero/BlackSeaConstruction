using System.Collections.Generic;

namespace BlackSeaConstruction.BusinessLogicLayer.ViewModels.Projects
{
    public class ProjectSectionVM
    {
        public int Id { get; set; }
        public string SectionName { get; set; }
        public string Description { get; set; }
        public string ProjectName { get; set; }
        public IEnumerable<string> Images { get; set; }
    }
}
