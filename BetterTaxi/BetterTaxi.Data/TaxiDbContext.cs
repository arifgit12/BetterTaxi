using BetterTaxi.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterTaxi.Data
{
    public interface ITaxiDbContext
    {
        IDbSet<Taxi> Taxies { get; set; }
        IDbSet<Order> Orders { get; set; }
        IDbSet<Photo> Photos { get; set; }
        IDbSet<Location> Locations { get; set; }
        IDbSet<T> Set<T>() where T : class;
        DbEntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
    public class TaxiDbContext : IdentityDbContext<ApplicationUser>, ITaxiDbContext
    {
        public TaxiDbContext()
            : base("BetterTaxiDbContext")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<TaxiDbContext, Configuration>());
        }

        public static TaxiDbContext Create()
        {
            return new TaxiDbContext();
        }

        public IDbSet<Taxi> Taxies { get; set; }
        public IDbSet<Order> Orders { get; set; }
        public IDbSet<Photo> Photos { get; set; }
        public IDbSet<Location> Locations { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new int SaveChanges()
        {
            int code = 0;
            try
            {
                code = base.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    foreach (var ve in eve.ValidationErrors)
                    {
                        // log
                    }
                }
                throw e;
            }
            catch (Exception e)
            {

                throw e;
            }

            return code;
        }
    }
}
