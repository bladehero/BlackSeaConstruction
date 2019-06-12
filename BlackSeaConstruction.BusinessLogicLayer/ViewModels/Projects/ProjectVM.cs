using System.Collections.Generic;

namespace BlackSeaConstruction.BusinessLogicLayer.ViewModels.Projects
{
    public class ProjectVM
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longtitude { get; set; }
        public IEnumerable<ProjectSectionVM> ProjectSections { get; set; }
    }
}
