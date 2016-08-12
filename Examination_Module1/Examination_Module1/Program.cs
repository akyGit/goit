/*
 * Author: Viktor Matyniuk
 * Date: 23 Jule, 2016
 * File: Program.cs
 * Description: Examination Module #1 (goit)
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationModule1 {
    class Program {
        static Int32 DisplayInviteAndGetValidNumber(String message, Int32 lowerBound, Int32 upperBound) {
            Int32 result;

            do {
                result = DisplayInviteAndGetNumber(message);
            } while (result < lowerBound || result > upperBound);

            return result;
        }

        static Int32 DisplayInviteAndGetNumber(String message) {
            Int32 result;

            do {
                Console.Write(message);
            } while (!Int32.TryParse(Console.ReadLine(), out result));

            return result;
        }

        static Boolean IsHaveDiscount() {
            Console.Write("Have you discount? <yes,no>: ");

            while (true) {
                switch (Console.ReadLine()) {
                    case "yes":
                        return true;
                    case "no":
                        return false;
                }
            }
        }

        static void Main(string[] args) {
            Product[] products = new Product[] {
                new Product("Apple",  10.50),
                new Product("Milk",   11.30),
                new Product("Coffee", 20.65),
                new Product("Fish",   15.40),
                new Product("Meat",   20.35),
                new Product("Bread",  7.15),
            };

            ProductList productList = new ProductList(products);
            Order order             = new Order(productList);

            const Int32 MAX_COUNT = 128;

            Console.Write("Please, Enter your name: ");
            Console.WriteLine("{0}, choose that you want to buy: ", Console.ReadLine());

            order.DisplayOrderMenu();

            Int32 currentPoint;
            Int32 currentCount;

            currentPoint = DisplayInviteAndGetValidNumber("Point: ", 1, order.ExitNumber);

            while (currentPoint != order.ExitNumber) { 
                currentCount = DisplayInviteAndGetValidNumber("Count: ", 0, MAX_COUNT);
                order.HandleChoice(currentPoint, currentCount);
                Console.WriteLine("\nNext choise:");
                currentPoint = DisplayInviteAndGetValidNumber("Point: ", 1, order.ExitNumber);
            }

            Int32 discount = 0;

            if (IsHaveDiscount()) {
                discount = DisplayInviteAndGetValidNumber("Enter a value of discount (in percentage): ", 0, 100);
            }

            order.DisplayCheck(discount);
        }
    }
}
