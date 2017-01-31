using BetterTaxi.Data;
using BetterTaxi.Models;
using BetterTaxi.Web.Infrastructure.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BetterTaxi.Web.Infrastructure.Populators
{
    public class DropDownListPopulator : IDropDownListPopulator
    {
        private ITaxiData data;
        private ICacheService cache;
        public const string ROLES_CACHE = "roles";
        public const string MANAGEMENT_ROLES_CACHE = "managementRoles";

        public DropDownListPopulator(ITaxiData data, ICacheService cache)
        {
            this.data = data;
            this.cache = cache;
        }
        public void clearCache(string cacheId)
        {
            this.cache.Clear(cacheId);
        }

        public IEnumerable<SelectListItem> GetRoles(ApplicationRoleManager manager)
        {
            var cachedRoles = this.cache.Get<IEnumerable<SelectListItem>>(ROLES_CACHE,
                () =>
                {
                    var roles = manager.Roles.ToList();
                    List<SelectListItem> roleItems = new List<SelectListItem>();

                    foreach (var role in roles)
                    {
                        roleItems.Add(new SelectListItem
                        {
                            Text = role.Name,
                            Value = role.Id
                        });
                    }
                    return roleItems;
                });
            return cachedRoles;
        }

        public IEnumerable<SelectListItem> GetRolesForManagement(ApplicationRoleManager manager)
        {
            var cachedRoles = this.cache.Get<IEnumerable<SelectListItem>>(MANAGEMENT_ROLES_CACHE,
               () =>
               {
                   var roles = manager.Roles.ToList();
                   List<SelectListItem> roleItems = new List<SelectListItem>();

                   foreach (var role in roles)
                   {
                       if (role.Name == UserRoles.Driver.ToString() || role.Name == UserRoles.Operator.ToString())
                       {
                           roleItems.Add(new SelectListItem
                           {
                               Text = role.Name,
                               Value = role.Id
                           });
                       }
                   }
                   return roleItems;
               });
            return cachedRoles;
        }
    }
}