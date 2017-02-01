using BetterTaxi.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BetterTaxi.Data;
using BetterTaxi.Web.Infrastructure.Populators;
using BetterTaxi.Models;
using BetterTaxi.Web.Infrastructure.Authorization;
using BetterTaxi.Web.Infrastructure.Services.Contracts;
using BetterTaxi.Web.Infrastructure.Services;
using BetterTaxi.Web.Areas.Administration.ViewModels;
using AutoMapper.QueryableExtensions;
using BetterTaxi.Web.ViewModels;

namespace BetterTaxi.Web.Areas.Administration.Controllers
{
    public static class MyExtensions
    {
        public static SelectList ToSelectList<TEnum>(this TEnum enumObj)
            where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            var values = from TEnum e in Enum.GetValues(typeof(TEnum))
                         select new { Id = e, Name = e.ToString() };
            return new SelectList(values, "Id", "Name", enumObj);
        }
    }

    [AuthorizeRoles(UserRole = UserRoles.Administrator)]
    public class RolesController : BaseController
    {
        private IAccountService services;
        public RolesController(ITaxiData data, IDropDownListPopulator populator) 
            : base(data, populator)
        {
            this.services = new AccountService(data);
        }

        // GET: Administration/Roles
        public ActionResult Index()
        {
            var rolesViewModel = new RolesAdministrationVM();

            rolesViewModel.Accounts = AutoMapper.Mapper.Map<ICollection<UserItemViewModel>>(this.services.AllUsers().ToList());
            
            ViewBag.UserRoles = this.populator.GetRoles(this.RoleManager);
            return View(rolesViewModel);
        }
    }
}