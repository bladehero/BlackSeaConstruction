namespace BlackSeaConstruction.DataAccessLayer.Models
{
    public class Service : BaseEntity
    {
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public int TypeId { get; set; }
    }
}
