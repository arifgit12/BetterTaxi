using BetterTaxi.Models;
using System.Linq;

namespace BetterTaxi.Web.Infrastructure.Services.Contracts
{
    public interface IAccountService
    {
        IQueryable<ApplicationUser> AllUsers();
        IQueryable<ApplicationUser> GetEmployees(IQueryable<ApplicationUser> users);
        IQueryable<ApplicationUser> WithFirstNameLike(IQueryable<ApplicationUser> users, string nameString);
        IQueryable<ApplicationUser> WithFullNameContaining(IQueryable<ApplicationUser> users, string nameString);
        IQueryable<ApplicationUser> WithLastNameLike(IQueryable<ApplicationUser> users, string nameString);
        IQueryable<ApplicationUser> WithMiddletNameLike(IQueryable<ApplicationUser> users, string nameString);
        IQueryable<ApplicationUser> WithRole(IQueryable<ApplicationUser> users, string roleId);
        string CreatePassword(int length);
    }
}
