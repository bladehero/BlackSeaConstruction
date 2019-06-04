namespace BlackSeaConstruction.DataAccessLayer.Models
{
    public class News : BaseEntity
    {
        public string Header { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Link { get; set; }
    }
}
