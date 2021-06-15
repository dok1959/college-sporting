using System;
using System.ComponentModel.DataAnnotations;

namespace CollegeSporting.Models
{
    public class UpdateIncidentViewModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Description can't be empty")]
        public string Description { get; set; }
        public DateTime? DateClosed { get; set; }
    }
}
