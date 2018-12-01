using System.Collections.Generic;
using ShopSnapWebApi.Models;

namespace ShopSnapWebApi.Controllers
{
    public interface IUserRepository
    {
        List<User> GetUsers();
    }
}