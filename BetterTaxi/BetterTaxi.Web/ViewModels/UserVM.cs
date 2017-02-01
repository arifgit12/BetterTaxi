using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BetterTaxi.Web.ViewModels
{
    public class UserVM
    {
        public string Id { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }
}