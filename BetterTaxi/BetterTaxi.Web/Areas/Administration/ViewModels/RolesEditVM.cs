using BetterTaxi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace BetterTaxi.Web.Areas.Administration.ViewModels
{
    public class RolesEditVM
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        
        [Required]
        public IEnumerable<SelectListItem> UserRoles { get; set; }

        public RolesEditVM()
        {
            this.UserRoles = new HashSet<SelectListItem>();
        }

        public static Expression<Func<ApplicationUser, RolesEditVM>> FromApplicationUserModel
        {
            get
            {
                return x => new RolesEditVM
                {
                    Id = x.Id,
                    Name = x.UserName,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber                    
                };
            }
        }
    }
}