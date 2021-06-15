using System;
using System.ComponentModel.DataAnnotations;

namespace CollegeSporting.Models
{
    public class Incident
    {
        public long Id { get; set; }

        public long CustomerId { get; set; }

        public long ProductId { get; set; }

        [Required(ErrorMessage = "Title can't be empty")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description can't be empty")]
        public string Description { get; set; }

        public long? TechnicianId { get; set; }

        public DateTime? DateOpened { get; set; }

        public DateTime? DateClosed { get; set; }

        public string GetDateTime(DateTime? date) // Method for getting a date based on its value 
        {
            if (date.HasValue)
                return date.ToString(); // Date string representation
            return ""; // String representation of an empty date
        }
    }
}