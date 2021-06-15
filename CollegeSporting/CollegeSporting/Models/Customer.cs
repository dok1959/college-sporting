using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CollegeSporting.Models
{
    public class Customer
    {
        public long Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "First name can't be empty")]
        [StringLength(51, ErrorMessage = "First Name length from 1 to 51 symbols")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Last name can't be empty")]
        [StringLength(51, ErrorMessage = "Last Name length from 1 to 51 symbols")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Address can't be empty")]
        [StringLength(51, ErrorMessage = "Address length from 1 to 51 symbols")]
        public string Address { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "City can't be empty")]
        [StringLength(51, ErrorMessage = "City length from 1 to 51 symbols")]
        public string City { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "State can't be empty")]
        [StringLength(51, ErrorMessage = "State length from 1 to 51 symbols")]
        public string State { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Postal code can't be empty")]
        [StringLength(21, ErrorMessage = "The postal code must be bigger then 1 digit and lesser than 21 digits)")]
        public string PostalCode { get; set; }

        //[Required(AllowEmptyStrings = false, ErrorMessage = "Country can't be empty")]
        public long? CountryId { get; set; }

        [EmailAddress(ErrorMessage = "Incorrect email address")]
        [StringLength(51, ErrorMessage = "Email length from 1 to 51 symbols")]
        public string Email { get; set; }

        [RegularExpression(@"\d{3}\d{3}\d{4}", ErrorMessage = "Incorrect phone number (Correct: (999) 999-9999)")]
        public string Phone { get; set; }

        //public ICollection<Registration> Registrations { get; set; }

        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }
    }
}