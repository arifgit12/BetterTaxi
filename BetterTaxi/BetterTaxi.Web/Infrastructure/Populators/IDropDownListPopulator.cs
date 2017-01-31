using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BetterTaxi.Web.Infrastructure.Populators
{
    public interface IDropDownListPopulator
    {
        IEnumerable<SelectListItem> GetRoles(ApplicationRoleManager manager);

        IEnumerable<SelectListItem> GetRolesForManagement(ApplicationRoleManager manager);

        void clearCache(string cacheId);
    }
}
