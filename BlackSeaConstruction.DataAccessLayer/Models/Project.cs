namespace BlackSeaConstruction.DataAccessLayer.Models
{
    public class Project : BaseEntity
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
    }
}
