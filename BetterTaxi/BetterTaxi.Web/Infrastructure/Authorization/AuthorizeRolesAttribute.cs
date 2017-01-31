using BetterTaxi.Models;
using System;
using System.Web.Mvc;

namespace BetterTaxi.Web.Infrastructure.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        public UserRoles UserRole { get; set; }
        public UserRoles SecondRole { get; set; }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (UserRole != 0)
            {
                Roles = UserRole.ToString();
                if (SecondRole != 0)
                {
                    Roles = Roles + "," + SecondRole.ToString();
                }
            }


            base.OnAuthorization(filterContext);
        }
    }
}