/*
 * Author: Viktor Matyniuk
 * Date: 15 August, 2016
 * Description: homework 10 (goit)
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework10 {
    static class Operations {
        public static void Plus(object sender, CalculateEventArgs args) {
            Console.WriteLine("Result: {0}", args.leftValue + args.rightValue);
        }

        public static void Minus(object sender, CalculateEventArgs args) {
            Console.WriteLine("Result: {0}", args.leftValue - args.rightValue);
        }

        public static void Divide(object sender, CalculateEventArgs args) {
            if (args.rightValue == 0) {
                Console.WriteLine("You can't divide by zero");
                return;
            }

            Console.WriteLine("Result: {0}", args.leftValue / args.rightValue);
        }

        public static void Multiply(object sender, CalculateEventArgs args) {
            Console.WriteLine("Result: {0}", args.leftValue * args.rightValue);
        }
    }
}
