using System.Collections.Generic;

namespace BlackSeaConstruction.Web.Areas.Admin.Models
{
    public class MergeServiceVM
    {
        public int? Id { get; set; }
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public int TypeId { get; set; }
        public IEnumerable<ServiceImageMergeVM> Images { get; set; }
    }

    public class ServiceImageMergeVM
    {
        public int? Id { get; set; }
        public string Image { get; set; }
        public bool? Updated { get; set; }
    }
}
