using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductCustomerMamnagement.DTOs
{
    public class CustomerDTO
    {
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "First Name field is required.")]
        [MaxLength(50, ErrorMessage = "First Name cannot exceed 50 characters.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name field is required.")]
        [MaxLength(50, ErrorMessage = "Last Name cannot exceed 50 characters.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email field is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }
        [Phone(ErrorMessage = "Invalid Phone Number.")]
        [StringLength(15, MinimumLength = 10, ErrorMessage = "Phone number must be between 10 and 15 digits.")]
        public string Phone { get; set; }

        [MaxLength(250, ErrorMessage = "Address cannot exceed 250 characters.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "The Date Joined field is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        [CustomValidation(typeof(CustomerDTO), nameof(ValidateDateJoined))]
        public System.DateTime DateJoined { get; set; }

        public static ValidationResult ValidateDateJoined(DateTime date, ValidationContext context)
        {
            if (date > DateTime.Now)
            {
                return new ValidationResult("Date Joined cannot be a future date.");
            }
            return ValidationResult.Success;
        }

    }
}
