namespace BlackSeaConstruction.DataAccessLayer.Models
{
    public class ServiceImage : BaseEntity
    {
        public int ServiceId { get; set; }
        public string Image { get; set; }
    }
}
