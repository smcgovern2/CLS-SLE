using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CLS_SLE.Models
{
    public class PasswordReset
    {
        [Required (ErrorMessage = "Login is required")]
        [StringLength(50)]
        public string Login { get; set; }
    }
}