namespace BlackSeaConstruction.DataAccessLayer.Models
{
    public class ProjectSection : BaseEntity
    {
        public string SectionName { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }
    }
}
