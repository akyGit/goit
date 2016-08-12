/*
 * Author: Viktor Matyniuk
 * Date: 12 Jule, 2016
 * Description: homework 1.1 (goit)
 */

using System;

namespace Homework1_1 {
    class Program {
        static void Main(string[] args) {
            System.String msgFormatNumbers  = "Type {0}: default value {1}, min {2}, max {3}";
            System.String msgFormatBoolChar = "Type {0}: default value {1}";

            Console.SetWindowSize(128, 16);

            Console.WriteLine(msgFormatNumbers, 
                "byte", 
                default(System.Byte), 
                System.Byte.MinValue, 
                System.Byte.MaxValue);

            Console.WriteLine(msgFormatNumbers, 
                "sbyte", 
                default(System.SByte), 
                System.SByte.MinValue, 
                System.SByte.MaxValue);

            Console.WriteLine(msgFormatNumbers, 
                "ushort", 
                default(System.UInt16), 
                System.UInt16.MinValue, 
                System.UInt16.MaxValue);

            Console.WriteLine(msgFormatNumbers, 
                "short", 
                default(System.Int16), 
                System.Int16.MinValue, 
                System.Int16.MaxValue);

            Console.WriteLine(msgFormatNumbers, 
                "uint", 
                default(System.UInt32), 
                System.UInt32.MinValue, 
                System.UInt32.MaxValue);

            Console.WriteLine(msgFormatNumbers, 
                "int", 
                default(System.Int32), 
                System.Int32.MinValue, 
                System.Int32.MaxValue);

            Console.WriteLine(msgFormatNumbers, 
                "ulong", 
                default(System.UInt64), 
                System.UInt64.MinValue, 
                System.UInt64.MaxValue);

            Console.WriteLine(msgFormatNumbers, 
                "long", 
                default(System.Int64), 
                System.Int64.MinValue, 
                System.Int64.MaxValue);

            Console.WriteLine(msgFormatNumbers,
                "float",
                default(System.Single),
                System.Single.MinValue,
                System.Single.MaxValue);

            Console.WriteLine(msgFormatNumbers,
                "double",
                default(System.Double),
                System.Double.MinValue,
                System.Double.MaxValue);

            Console.WriteLine(msgFormatNumbers,
                "decimal",
                default(System.Decimal),
                System.Decimal.MinValue,
                System.Decimal.MaxValue);

            Console.WriteLine(msgFormatBoolChar,
                "bool",
                default(System.Boolean));

            Console.WriteLine(msgFormatBoolChar,
                "char",
                default(System.Char));
        }
    }
}
