﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CLS_SLE.Models
{
    public class UserSignIn
    {
        public int PersonID { get; set; }
        [Required(ErrorMessage = "Password Required")]
        public string Hash { get; set; }
    }
}