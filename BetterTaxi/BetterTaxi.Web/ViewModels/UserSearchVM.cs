using System;
using System.ComponentModel.DataAnnotations;

namespace BetterTaxi.Web.ViewModels
{
    public class UserSearchVM
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Role")]
        public string[] SelectedRoleIds { get; set; }
    }
}