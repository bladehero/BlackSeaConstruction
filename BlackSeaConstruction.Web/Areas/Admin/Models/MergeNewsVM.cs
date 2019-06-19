namespace BlackSeaConstruction.Web.Areas.Admin.Models
{
    public class MergeNewsVM
    {
        public int? Id { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Image { get; set; }
        public bool? Updated { get; set; }
    }
}
