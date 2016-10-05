using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework15 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("1. demo clean table");
            Console.WriteLine("Push button to start demo");
            Console.ReadKey();
            DatabaseController.CleanTable(DatabaseController.Tables.Product);
            DatabaseController.CleanTable(DatabaseController.Tables.Sale);
            Console.WriteLine("Table Product and Sale are clean");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("2. demo of creating product entries");
            Console.WriteLine("Push button to start demo");
            Console.ReadKey();
            Product[] products = {
                new Product() { Name = "bread", Price = 6.5M  },
                new Product() { Name = "milk",  Price = 12.4M },
                new Product() { Name = "meat",  Price = 80.5M }
            };

            DatabaseController.CreateEntries(products);

            List<Product> productList = DatabaseController.GetProductsList();
            Console.WriteLine("Product table: ");
            foreach (Product prod in productList) {
                Console.WriteLine("  id: {0}; name: {1}; price: {2};",
                    prod.ProductId, prod.Name, prod.Price);
            }
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("3. demo of adding and removing entry");
            Console.WriteLine("Push button to add sale entry");
            Console.ReadKey();
            Sale sale = new Sale() {
                SaleId = productList.First().ProductId,
                Sum = 423
            };

            DatabaseController.CreateEntry(sale);

            List<Sale> saleList = DatabaseController.GetSalesList();
            Console.WriteLine("Sale table: ");
            foreach (Sale s in saleList)
                Console.WriteLine("   id: {0}; sum: {1};", s.SaleId, s.Sum);
            Console.WriteLine();

            Console.WriteLine("Push button for removing of sale entry");
            Console.ReadKey();
            DatabaseController.RemoveEntryById(DatabaseController.Tables.Sale, saleList[0].SaleId);

            saleList = DatabaseController.GetSalesList();
            Console.WriteLine("Sale table: ");
            foreach (Sale s in saleList)
                Console.WriteLine("   id: {0}; sum: {1};", s.SaleId, s.Sum);
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("4. demo of sale effect");
            Console.WriteLine("Push button to start demo");
            Console.ReadKey();
            foreach (Product prod in productList) {
                DatabaseController.Sale(prod.ProductId, 10);
            }

            saleList = DatabaseController.GetSalesList();
            Console.WriteLine("Sale table: ");
            foreach (Sale s in saleList)
                Console.WriteLine("   id: {0}; sum: {1};", s.SaleId, s.Sum);
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("5. demo of getting data");
            Console.WriteLine("Push button to start demo");
            Console.ReadKey();
            Console.WriteLine("Data table: ");
            foreach (Product prod in productList) {
                DataEntry data = DatabaseController.GetDataEntryById(prod.ProductId);
                if (data != default(DataEntry))
                    Console.WriteLine("   Name: {0}; Price: {1}; Sum: {2};", data.Name, data.Price, data.Sum);
            }
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("6. demo of editing entries");
            Console.WriteLine("Push button to start demo");
            Console.ReadKey();
            foreach (Product prod in productList) {
                DatabaseController.ChangeProductNameById(prod.ProductId, "hubbabubba");
            }

            productList = DatabaseController.GetProductsList();
            Console.WriteLine("New name for all products: ");
            foreach (Product prod in productList) {
                Console.WriteLine("id: {0}; name: {1}; price: {2};",
                    prod.ProductId, prod.Name, prod.Price);
            }
            Console.WriteLine("-----------------------------------------------------------");
        }
    }
}
