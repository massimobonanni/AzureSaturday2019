using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Entities
{
    internal static class ProductsHelper
    {

        public static IEnumerable<Product> GenerateProducts()
        {
            var productList = new List<Product>();

            productList.Add(new Product()
            {
                Id = 1,
                Title = "Mortadella Bologna",
                Description = "Mortadella IGP bologna con pistacchio di prima qualità",
                ShortDescription = "Mortadella IGP bologna con pistacchio di prima qualità",
                StoreQuantity = 10,
                UnitPrice = 15.50M
            });

            productList.Add(new Product()
            {
                Id = 2,
                Title = "Prosciutto cotto",
                Description = "Prosciutto cotto senza polifosfati aggiunti.",
                ShortDescription = "Prosciutto cotto senza polifosfati.",
                StoreQuantity = 15,
                UnitPrice = 10.75M
            });

            productList.Add(new Product()
            {
                Id = 3,
                Title = "Prosciutto crudo Parma",
                Description = "Prosciutto crudo dop Parma di qualità superiore",
                ShortDescription = "Prosciutto crudo dop Parma di qualità superiore",
                StoreQuantity = 32,
                UnitPrice = 20.65M
            });

            productList.Add(new Product()
            {
                Id = 4,
                Title = "Salame Milano",
                Description = "Il celebre salame Milano dal gusto inconfondibile",
                ShortDescription = "Il celebre salame Milano dal gusto inconfondibile",
                StoreQuantity = 16,
                UnitPrice = 12.65M
            });

            return productList;
        }
    }
}
