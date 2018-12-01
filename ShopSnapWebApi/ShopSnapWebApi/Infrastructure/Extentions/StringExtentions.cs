using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopSnapWebApi.Infrastructure.Extentions
{
    public static class StringExtentions
    {
        public static int ConvertToCents(this string str)
        {
            int result = 0;
            string[] arr = str.Split(',');
            try
            {
                int euros = int.Parse(arr[0]);
                int cents = int.Parse(arr[1]);
                result = euros * 100 + cents;
            }
            catch
            {

            }
            return result;
        }
    }
}