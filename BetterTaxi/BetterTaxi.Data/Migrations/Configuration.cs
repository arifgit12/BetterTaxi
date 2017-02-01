using BetterTaxi.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterTaxi.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<TaxiDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TaxiDbContext context)
        {
            foreach (UserRoles role in Enum.GetValues(typeof(UserRoles)))
            {
                if (!context.Roles.Any(r => r.Name == role.ToString()))
                {
                    var store = new RoleStore<IdentityRole>(context);
                    var manager = new RoleManager<IdentityRole>(store);
                    var newRole = new IdentityRole { Name = role.ToString() };
                    manager.Create(newRole);
                }
            }

            if (!context.Users.Any(u => u.UserName == "bboyadzhiev@gmail.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser
                {
                    UserName = "bboyadzhiev@gmail.com",
                    FirstName = "Borislav",
                    MiddleName = "Vladimirov",
                    LastName = "Boyadzhiev",
                    Email = "bboyadzhiev@gmail.com",
                    PhoneNumber = "0886176803"
                };

                manager.Create(user, "passW0RD");
                manager.AddToRole(user.Id, UserRoles.Administrator.ToString());
                manager.AddToRole(user.Id, UserRoles.Manager.ToString());
                manager.AddToRole(user.Id, UserRoles.Operator.ToString());
            }

            if (!context.Users.Any(u => u.UserName == "arifali.mondal@gmail.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser
                {
                    UserName = "arifali.mondal@gmail.com",
                    FirstName = "Arif",
                    MiddleName = "Ali",
                    LastName = "Mondal",
                    Email = "arifali.mondal@gmail.com",
                    PhoneNumber = "0538557493"
                };

                manager.Create(user, "Admin@123");
                manager.AddToRole(user.Id, UserRoles.Administrator.ToString());
                manager.AddToRole(user.Id, UserRoles.Manager.ToString());
                manager.AddToRole(user.Id, UserRoles.Operator.ToString());
            }

            if (!context.Users.Any(u => u.UserName == "jack@getataxi.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);

                var demoManager = new ApplicationUser
                {
                    UserName = "jack@getataxi.com",
                    FirstName = "Jasper",
                    MiddleName = "Newton",
                    LastName = "Daniel",
                    Email = "jack@getataxi.com",
                    PhoneNumber = "0888333111"
                };

                manager.Create(demoManager, "Admin@123");
                manager.AddToRole(demoManager.Id, UserRoles.Manager.ToString());
            }

            if (!context.Users.Any(u => u.UserName == "shisho@getataxi.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);

                var demoDriver = new ApplicationUser
                {
                    UserName = "shisho@getataxi.com",
                    FirstName = "Shisho",
                    MiddleName = "D.",
                    LastName = "Bakshisho",
                    Email = "shisho@getataxi.com",
                    PhoneNumber = "0888000111"
                };

                manager.Create(demoDriver, "Admin@123");
                manager.AddToRole(demoDriver.Id, UserRoles.Driver.ToString());
            }

            if (!context.Users.Any(u => u.UserName == "maryjane@getataxi.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var demoUser = new ApplicationUser
                {
                    UserName = "maryjane@getataxi.com",
                    FirstName = "Mary",
                    MiddleName = "Jane",
                    LastName = "Watson",
                    Email = "maryjane@getataxi.com",
                    PhoneNumber = "0888222555"
                };

                manager.Create(demoUser, "Admin@123");
                manager.AddToRole(demoUser.Id, UserRoles.Driver.ToString());
            }

            if (!context.Users.Any(u => u.UserName == "charlie@getataxi.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);

                var demoOperator2 = new ApplicationUser
                {
                    UserName = "charlie@getataxi.com",
                    FirstName = "Charlie",
                    MiddleName = "Donathan",
                    LastName = "Doe",
                    Email = "charlie@getataxi.com",
                    PhoneNumber = "0888222666"
                };

                manager.Create(demoOperator2, "charlie");
                manager.AddToRole(demoOperator2.Id, UserRoles.Operator.ToString());
            }
        }
    }
}
