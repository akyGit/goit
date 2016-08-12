/*
 * Author: Viktor Matyniuk
 * Date: 12 Jule, 2016
 * Description: homework 1.2 (goit)
 */

using System;

namespace Homework1_2 {
    class Program {
        static void Main(string[] args) {
            System.String msg = "Hello world";

            Console.SetWindowSize(64, 16);

            foreach (char c in msg) {
                System.Int16 currentChar = Convert.ToInt16(c);
                Console.WriteLine("Char {0}: dec {1,3:d}, hex {1,2:x}", c, currentChar);
            }
        }
    }
}
