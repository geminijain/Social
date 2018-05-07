using System;
using System.ComponentModel.DataAnnotations;

namespace Social.Models
{
    public class Event
    {
        public int Id { get; set; }

        public ApplicationUser Organizer { get; set; }

        [Required]
        public string OrganizerId { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Venue { get; set; }

        public Category Category { get; set; }

        [Required]
        public byte CategoryId { get; set; }
    }
}