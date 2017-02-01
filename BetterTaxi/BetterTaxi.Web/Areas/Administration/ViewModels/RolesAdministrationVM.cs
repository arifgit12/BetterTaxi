using BetterTaxi.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BetterTaxi.Web.Areas.Administration.ViewModels
{
    public class RolesAdministrationVM
    {
        public ICollection<UserItemViewModel> Accounts { get; set; }
        public string SelectedRoleId { get; set; }
        public IEnumerable<SelectListItem> UserRoles { get; set; }
    }
}