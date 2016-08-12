/*
 * Author: Viktor Matyniuk
 * Date: 23 Jule, 2016
 * File: ProductList.cs
 * Description: Examination Module #1 (goit)
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationModule1 {
    class ProductList {
        public ProductList() {
            productList = new List<Product>();
        }

        public ProductList(Product[] products) {
            productList = new List<Product>(products);
        }

        public void AddProduct(Product product) {
            productList.Add(product);
        }

        public void DisplayList() {
            for (Int32 i = 0; i < productList.Count; i++) {
                Console.WriteLine("{0,3}. {1,-10}: $ {2,6:F2}", i+1, productList[i].Name, productList[i].Price);
            }
        }

        public String GetNameByIndex(Int32 index) {
            return productList[index].Name;
        }

        public Double GetPriceByIndex(Int32 index) {
            return productList[index].Price;
        }

        public Int32 Count {
            get {
                return productList.Count;
            }
        }

        private List<Product> productList;
    }
}
