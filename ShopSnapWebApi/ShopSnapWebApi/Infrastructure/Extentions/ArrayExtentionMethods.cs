using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopSnapWebApi.Infrastructure.Extentions
{
    public static class ArrayExtentionMethods
    {
        public static T[] SubArray<T>(this T[] data, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }
    }
}