using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSnapWebApi.Interfaces
{
    public interface IUserSpendingsRepository
    {
        decimal GetUserAllSpendings(int userID, bool isProductCount = false);
    }
}
