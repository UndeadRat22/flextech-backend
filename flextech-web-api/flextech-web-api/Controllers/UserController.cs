using flextech_web_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace flextech_web_api.Controllers
{
    public class UserController : ApiController
    {
        public List<User> Get()
        {
            using(FlextechDatabaseContext db = new FlextechDatabaseContext())
            {
                return db.Users.ToList();
            }
        }
    }
}
