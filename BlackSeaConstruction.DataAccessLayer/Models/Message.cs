namespace BlackSeaConstruction.DataAccessLayer.Models
{
    public class Message : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public string Status { get; set; }
    }
}
