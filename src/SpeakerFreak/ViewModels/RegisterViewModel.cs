﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpeakerFreak.ViewModels
{
    public class RegisterViewModel
    {

      

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set;}

     
        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name="Confirm password")]
        [Compare("Password", ErrorMessage = "Passwords do not match!")]
        public string ConfirmPassword { get; set; }
    }
}

// Have to know add Register View .cshtml e.g account/register
