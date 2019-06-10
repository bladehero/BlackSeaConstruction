using System;
using System.ComponentModel.DataAnnotations;

namespace BlackSeaConstruction.BusinessLogicLayer.ViewModels.Messages
{
    public class MessageVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Text { get; set; }
        public Status Status { get; set; }
        public DateTime ReceivedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
