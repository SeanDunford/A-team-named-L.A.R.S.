using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace BayHelper.Com.Models
{

    public class ChangePasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LogOnModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        //Address
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }
        
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Street 1")]
        public String Street1 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Street 1")]
        public String Street2 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "City")]
        public String City { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "State")]
        public String State { get; set; }

        [Display(Name = "Zip")]
        [StringLength(10, ErrorMessage = "The Zip Code must be at most 10 characters long.")]
        public String Zip { get; set; }
    }
}
