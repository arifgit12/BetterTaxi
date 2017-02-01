using BetterTaxi.Data;
using BetterTaxi.Models;
using BetterTaxi.Web.Infrastructure.Populators;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BetterTaxi.Web.Controllers
{
    public class BaseController : Controller
    {
        protected ITaxiData Data { get; private set; }        
        protected IDropDownListPopulator populator;

        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;

        public BaseController(ITaxiData data, IDropDownListPopulator populator)
        {
            this.Data = data;
            this.populator = populator;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }        
    }
}