using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCAutoSparkProject.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is mandatory")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Phone Number is mandatory")]
        public long PhoneNumber { get; set; }
        [Required(ErrorMessage = "EmailId is mandatory")]
        public string EmailId { get; set; }
        [Required(ErrorMessage = "Address is mandatory")]
        public string Address { get; set; }
        [Required(ErrorMessage = "City is mandatory")]
        public string City { get; set; }
        [Required(ErrorMessage = "PostalCode is mandatory")]

        public string PostalCode { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

    }
}