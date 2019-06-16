using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace BlackSeaConstruction.Web.Areas.Admin.Models
{
    public class WorkAddOrUpdateVM
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double? Latitude { get; set; }
        public double? Longtitude { get; set; }
        public IEnumerable<WorkSectionVM> Sections { get; set; }
    }

    public class WorkSectionVM
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<WorkSectionImageVM> Images { get; set; }
    }

    public class WorkSectionImageVM
    {
        public int? Id { get; set; }
        public bool Updated { get; set; }
        public string FileName { get; set; }
    }
}
