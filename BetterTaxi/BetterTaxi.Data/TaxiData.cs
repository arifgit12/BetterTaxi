using BetterTaxi.Data.Repositories;
using BetterTaxi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterTaxi.Data
{
    public interface ITaxiData
    {
        IRepository<ApplicationUser> Users { get; }
        IRepository<Taxi> Taxies { get; }
        IRepository<Order> Orders { get; }
        IRepository<Photo> Photos { get; }
        IRepository<Location> Locations { get; }
        int SaveChanges();
    }
    public class TaxiData : ITaxiData
    {
        private readonly ITaxiDbContext context;
        private readonly IDictionary<Type, object> repositories;

        public TaxiData()
            : this(new TaxiDbContext())
        {

        }
        
        public TaxiData(ITaxiDbContext ctx)
        {
            this.context = ctx;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<ApplicationUser> Users
        {
            get
            {
                return this.GetRepository<ApplicationUser>();
            }
        }


        public IRepository<Taxi> Taxies
        {
            get
            {
                return this.GetRepository<Taxi>();
            }
        }
       

        public IRepository<Order> Orders
        {
            get
            {
                return this.GetRepository<Order>();
            }
        }

        public IRepository<Photo> Photos
        {
            get
            {
                return this.GetRepository<Photo>();
            }
        }
        
        public IRepository<Location> Locations
        {
            get
            {
                return this.GetRepository<Location>();
            }
        }
        
        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }
        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(Repository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }
            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}
