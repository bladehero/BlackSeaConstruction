namespace BlackSeaConstruction.DataAccessLayer.Models
{
    public class ProjectSection : BaseEntity
    {
        public string SectionName { get; set; }
        public int ProjectId { get; set; }
    }
}
