using System.ComponentModel.DataAnnotations;

namespace CollegeSporting.Models
{
    public class Technician
    {
        public long Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Full name can't be empty")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email address can't be empty")]
        [EmailAddress(ErrorMessage = "Incorrect email address")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone number can't be empty")]
        [RegularExpression(@"\d{3}\d{3}\d{4}", ErrorMessage = "Incorrect phone number (Correct: 999-999-9999)")]
        public string Phone { get; set; }

        public string GetCorrectPhoneNumber()
        {
            return Phone.Substring(0, 3) + "-" + Phone.Substring(3, 3) + "-" + Phone.Substring(6, 4);
        }
    }
}
