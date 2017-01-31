using BetterTaxi.Models;
using BetterTaxi.Web.Infrastructure.Authorization;
using System;
using System.Web.Mvc;

namespace BetterTaxi.Web.Areas.Management.Controllers
{
    [AuthorizeRoles(UserRole = UserRoles.Administrator, SecondRole = UserRoles.Manager)]
    public class TaxiesController : Controller
    {
        // GET: Management/Taxies
        public ActionResult Index()
        {
            return View();
        }
    }
}