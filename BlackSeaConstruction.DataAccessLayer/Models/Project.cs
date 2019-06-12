namespace BlackSeaConstruction.DataAccessLayer.Models
{
    public class Project : BaseEntity
    {
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longtitude { get; set; }
    }
}
