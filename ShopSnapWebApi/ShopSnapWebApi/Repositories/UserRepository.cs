using ShopSnapWebApi.Controllers;
using ShopSnapWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopSnapWebApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        public List<User> GetUsers()
        {
            using (var db = new ShopSnapDatabaseContext())
            {
                return db.Users.ToList();
            }
        }

        public User GetUserByID(int userID)
        {
            using (var db = new ShopSnapDatabaseContext())
            {
                return db.Users.FirstOrDefault(u => u.ID == userID);
            }
        }
    }
}