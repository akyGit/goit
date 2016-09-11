/*
 * Author: Viktor Matyniuk
 * Date: 10 September, 2016
 * Description: homework 14 (goit)
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework14 {
    class Program {
        static void Main(string[] args) {
            List<ShopItem> data = GetShopData();

            #region task 1
            var resultTask_1 = data
                .Where(item => item.Discount != 0)
                .Where(item => item.Price <= 1000)
                .Where(item => item.Amount > 2)
                .Where(item => item.Name.Contains("new"))
                .Select(item => new {
                    Id = item.Id,
                    Summary = item.Summary
                });

            Console.WriteLine("Result of task 1:");
            foreach (var item in resultTask_1)
                Console.WriteLine("  id: {0}; Summary: {1}", item.Id, item.Summary);
            Console.WriteLine();
            #endregion

            #region task 2
            // demonstration of result of method Tools.Page which you can find below 
            var resultTask_2 = data.Page(2);

            Console.WriteLine("Result of task 2:");
            foreach (var item in resultTask_2)
                Console.WriteLine("  {0}", item.Name);
            Console.WriteLine();
            #endregion

            #region task 3
            // demonstration of result of method Tools.ByKeyNames which you can find below 
            var resultTask_3 = data.ByKeyNames(new List<string>() { "new", "Pizza", "Ban" });

            Console.WriteLine("Result of task 3:");
            foreach (var item in resultTask_3)
                Console.WriteLine("  {0}", item.Name);
            Console.WriteLine();
            #endregion
        }

        static List<ShopItem> GetShopData() {
            List<ShopItem> result = new List<ShopItem>();

            int i = 0;

            result.Add(new ShopItem() { Id = i++, Name = "Car",                 Price = 10000.0, Amount = 3,   Discount = 30 });
            result.Add(new ShopItem() { Id = i++, Name = "Book",                Price = 14.5,    Amount = 300, Discount = 0  });
            result.Add(new ShopItem() { Id = i++, Name = "new Cycle",           Price = 200.0,   Amount = 53,  Discount = 10 });
            result.Add(new ShopItem() { Id = i++, Name = "Motorcycle",          Price = 7000.0,  Amount = 1,   Discount = 5  });
            result.Add(new ShopItem() { Id = i++, Name = "new Doll",            Price = 20.0,    Amount = 89,  Discount = 0  });
            result.Add(new ShopItem() { Id = i++, Name = "Bottle of water",     Price = 8.0,     Amount = 543, Discount = 0  });
            result.Add(new ShopItem() { Id = i++, Name = "Banan",               Price = 29.5,    Amount = 63,  Discount = 0  });
            result.Add(new ShopItem() { Id = i++, Name = "new Sausage",         Price = 45.0,    Amount = 90,  Discount = 0  });
            result.Add(new ShopItem() { Id = i++, Name = "Tomato",              Price = 30.0,    Amount = 100, Discount = 0  });
            result.Add(new ShopItem() { Id = i++, Name = "Pizza",               Price = 110.0,   Amount = 25,  Discount = 0  });
            result.Add(new ShopItem() { Id = i++, Name = "Sandwich",            Price = 30.0,    Amount = 300, Discount = 0  });
            result.Add(new ShopItem() { Id = i++, Name = "Juice",               Price = 16.0,    Amount = 150, Discount = 5  });
            result.Add(new ShopItem() { Id = i++, Name = "new Hat",             Price = 350.0,   Amount = 11,  Discount = 10 });
            result.Add(new ShopItem() { Id = i++, Name = "Umbrella",            Price = 250.0,   Amount = 19,  Discount = 5  });
            result.Add(new ShopItem() { Id = i++, Name = "new Bag",             Price = 600.0,   Amount = 8,   Discount = 15 });
            result.Add(new ShopItem() { Id = i++, Name = "Shoes",               Price = 1200.0,  Amount = 22,  Discount = 5  });
            result.Add(new ShopItem() { Id = i++, Name = "Theater ticket",      Price = 200.0,   Amount = 643, Discount = 0  });
            result.Add(new ShopItem() { Id = i++, Name = "new Airplane ticket", Price = 7000.0,  Amount = 334, Discount = 10 });
            result.Add(new ShopItem() { Id = i++, Name = "new Airplane ticket", Price = 7000.0,  Amount = 334, Discount = 10 });

            return result;
        }
    }

    static class Tools {
        public static IEnumerable<TSource> Page<TSource>(this IEnumerable<TSource> source, int page, int pageSize = 2) {
            return source.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public static IEnumerable<ShopItem> ByKeyNames(this IEnumerable<ShopItem> source, List<String> keys) {
            return source.Where(item => keys.Any(key => item.Name.Contains(key)));
        }
    }
}
