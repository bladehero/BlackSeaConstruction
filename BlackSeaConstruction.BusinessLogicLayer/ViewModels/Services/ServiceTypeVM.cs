using System.Collections.Generic;

namespace BlackSeaConstruction.BusinessLogicLayer.ViewModels.Services
{
    public class ServiceTypeVM
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public bool IsDeleted { get; set; }
        public IEnumerable<ServiceVM> Services { get; set; }
    }
}
