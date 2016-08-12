/*
 * Author: Viktor Matyniuk
 * Date: 23 Jule, 2016
 * File: Order.cs
 * Description: Examination Module #1 (goit)
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationModule1 {
    class Order {
        public Order(ProductList productList) {
            this.productList = productList;
            productCounts    = new Int32[productList.Count];
        }

        public void DisplayOrderMenu() {
            Console.WriteLine("-------------- Products --------------");
            productList.DisplayList();
            Console.WriteLine("{0,3}. Exit", productList.Count + 1);
            Console.WriteLine("--------------------------------------");
        }

        public Int32 ExitNumber {
            get {
                return productList.Count + 1;
            }
        }

        public void HandleChoice(Int32 point, Int32 count) {
            productCounts[point - 1] += count;
        }

        public void DisplayCheck(Int32 discount = 0) {
            Double total         = 0;
            Double totalDiscount = 0;

            Console.WriteLine("-------------- Check --------------");
            for (Int32 i = 0; i < productCounts.Length; i++) {
                if (productCounts[i] != 0) {
                    Double currentAmount = productList.GetPriceByIndex(i) * productCounts[i];
                    Console.WriteLine(
                        "{0,-10} x {1, 3} = $ {2,7:F2}", 
                        productList.GetNameByIndex(i), 
                        productCounts[i],
                        currentAmount
                    );
                    total += currentAmount;
                }
            }

            totalDiscount = total * (((Double)discount) / 100);
            total -= totalDiscount;

            Console.WriteLine("Total discount: $ {0,7:F2}", totalDiscount);
            Console.WriteLine("For payment:    $ {0,7:F2}", total);
            Console.WriteLine("-----------------------------------");
        }

        private ProductList productList;
        private Int32[]     productCounts;
    }
}
