using ShopSnapWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShopSnapWebApi.Controllers
{
    public class UserController : ApiController
    {
        public List<User> GetUsers()
        {
            using(var db = new ShopSnapDatabaseContext())
            {
                return db.Users.ToList();
            }
        }
    }
}
