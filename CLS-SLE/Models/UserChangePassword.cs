using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CLS_SLE.Models
{
    public class UserChangePassword
    {
        [Required(ErrorMessage = "Current Password Required")]
        [PasswordPropertyText]
        [DisplayName("Current Password")]
        public string Hash { get; set; }

        [Required(ErrorMessage = "New Password Required")]
        [PasswordPropertyText]
        [StringLength(16, MinimumLength = 8)]
        [DisplayName("New Password")]
        public string NewHash { get; set; }

        [Required(ErrorMessage = "Confirmation Password Required")]
        [PasswordPropertyText]
        [StringLength(16, MinimumLength = 8)]
        [DisplayName("Confirm Password")]
        [Compare("NewHash", ErrorMessage = "Passwords Do Not Match")]
        public string ConfirmNewHash { get; set; }
    }
}