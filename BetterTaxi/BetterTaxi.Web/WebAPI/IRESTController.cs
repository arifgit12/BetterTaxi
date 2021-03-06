﻿namespace BetterTaxi.Web.WebAPI
{
    using System.Web.Http;

    public interface IRESTController<T>
    {
        IHttpActionResult Get();

        IHttpActionResult Get(int id);

        IHttpActionResult GetPaged(int page);

        IHttpActionResult Post([FromBody]T model);

        IHttpActionResult Put([FromBody]T model);

        IHttpActionResult Delete(int id);
    }
}
