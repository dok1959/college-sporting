using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CollegeSporting.Models
{
    public class Product
    {
        public long Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Code can't be empty")]
        public string Code { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Name can't be empty")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Price can't be empty")]
        public decimal Price { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Release date can't be empty")]
        public DateTime Release { get; set; }
    }
}
