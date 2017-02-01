using BetterTaxi.Models;
using System.Linq;

namespace BetterTaxi.Web.Infrastructure.Services.Contracts
{
    public interface ITaxiService
    {
        IQueryable<Taxi> AllTaxies();
        IQueryable<Taxi> WithPlateLike(IQueryable<Taxi> taxies, string plate);
        IQueryable<Taxi> WithTaxiStandTitleLike(IQueryable<Taxi> taxies, string taxiStandTitle);
        IQueryable<Taxi> WithDistrictTitleLike(IQueryable<Taxi> taxies, string districtTitle);
    }
}
