using System;

namespace BlackSeaConstruction.BusinessLogicLayer.ViewModels.Messages
{
    public class MessageVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public string Status { get; set; }
        public DateTime ReceivedAt { get; set; }
    }
}
