using BetterTaxi.Data;
using BetterTaxi.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BetterTaxi.Web.WebAPI
{
    public class BaseApiController : ApiController
    {
        protected ITaxiData Data;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">Instance of the data context</param>
        public BaseApiController(ITaxiData data)
        {
            this.Data = data;
        }

        #region Helpers
        [NonAction]
        public ApplicationUser GetUser()
        {
            string userId = this.User.Identity.GetUserId();
            var user = this.Data.Users.All().FirstOrDefault(u => u.Id == userId);
            return user;
        }
        #endregion
    }
}
