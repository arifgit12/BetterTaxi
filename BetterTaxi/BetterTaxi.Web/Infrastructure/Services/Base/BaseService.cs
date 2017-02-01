using BetterTaxi.Data;

namespace BetterTaxi.Web.Infrastructure.Services.Base
{
    public abstract class BaseService
    {
        protected ITaxiData Data;

        public BaseService(ITaxiData data)
        {
            this.Data = data;
        }
    }
}