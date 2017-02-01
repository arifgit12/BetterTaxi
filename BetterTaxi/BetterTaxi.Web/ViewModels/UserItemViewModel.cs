using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BetterTaxi.Web.ViewModels
{
    public class UserItemViewModel : UserVM
    {
        [Required]
        [Display(Name = "Roles")]
        public List<string> Roles { get; set; }
    }
}