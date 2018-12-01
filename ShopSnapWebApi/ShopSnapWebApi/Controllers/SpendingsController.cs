using ShopSnapWebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShopSnapWebApi.Controllers
{
    public class SpendingsController : ApiController
    {
        IUserSpendingsRepository _userSpendingsRepository;

        public SpendingsController(IUserSpendingsRepository userSpendingsRepository)
        {
            _userSpendingsRepository = userSpendingsRepository;
        }

        public decimal GetUserAllSpendings(int userID, bool isProductCount = false)
        {
            return _userSpendingsRepository.GetUserAllSpendings(userID, isProductCount);
        }
    }
}
