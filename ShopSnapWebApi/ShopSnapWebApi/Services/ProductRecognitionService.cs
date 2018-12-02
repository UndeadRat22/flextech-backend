using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ShopSnapWebApi.Models;

namespace ShopSnapWebApi.Services
{   
    public class ProductRecognitionService
    {
        // @@@ Will be replace with legit string
        private static List<string> queries = new List<string>
        {
            "Name = '@@@'",
            "Name LIKE '@@@%'",
            "Name LIKE '%@@@%'"
        };

        public static Product recognize(string productName)
        {
            string searchableName;
            
            if (productName.Length >= 7)
            {
                searchableName = productName.Substring(0, 6);
            }
            else
            {
                searchableName = productName.Substring(0, 5);
            }

            using (var context = new ShopSnapDatabaseContext())
            {
                foreach (var query in queries)
                {
                    var formattedQuery = getFormattedQuery(query, searchableName);
                    Debug.WriteLine(formattedQuery);
                    System.Console.WriteLine(formattedQuery);
                    var products = context.Products.SqlQuery(formattedQuery).ToList();

                    if (products.Count > 0)
                    {
                        return products.First();
                    }
                }
            }

            return null;
        }

        private static string getFormattedQuery(string query, string subject)
        {
            var formattedQuery =  query.Replace("@@@", subject);

            return "SELECT * FROM Products WHERE " + formattedQuery;
        }
    }
}