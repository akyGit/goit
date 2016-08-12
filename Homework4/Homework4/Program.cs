/*
 * Author: Viktor Matyniuk
 * Date: 19 Jule, 2016
 * Description: homework 4 (goit)
 */

using System;

namespace Homework4 {
    class Program {
        enum Operation : Int32 { UNKNOW, EXIT, PLUS, MINUS, DIV, MUL, MOD, POW }

        static Double Sum(Double val1, Double val2) {
            return val1 + val2;
        }

        static Double Subtract(Double val1, Double val2) {
            return val1 - val2;
        }

        static Double Divide(Double val1, Double val2) {
            return val1 / val2;
        }

        static Double Multiply(Double val1, Double val2) {
            return val1 * val2;
        }

        static Double Mod(Double val1, Double val2) {
            return val1 % val2;
        }

        static Double Pow(Double val1, Double val2) {
            return Math.Pow(val1, val2);
        }

        static Double GetValue() {
            Double result = default(Double);

            do {
                Console.Write("Enter value: ");
            } while (!Double.TryParse(Console.ReadLine(), out result));

            return result;
        }

        static Operation GetOperation() {
            Console.Write("Enter operation: ");
            String localOperation = Console.ReadLine();
            switch (localOperation) {
                case "exit":
                    return Operation.EXIT;
                case "+":
                    return Operation.PLUS;
                case "-":
                    return Operation.MINUS;
                case "/":
                    return Operation.DIV;
                case "*":
                    return Operation.MUL;
                case "%":
                    return Operation.MOD;
                case "pow":
                    return Operation.POW;
                default:
                    return Operation.UNKNOW;
            }
        }

        static Operation GetValidOperation() {
            Operation result = Operation.UNKNOW;

            while ((result = GetOperation()) == Operation.UNKNOW) ;

            return result;
        }

        static void ShowResult(Double value) {
            Console.WriteLine("result = {0}", value);
        }

        /// <summary>
        /// Return result of expression. If operation is unknow by default it's PLUS
        /// </summary>
        /// <param name="val1">first value</param>
        /// <param name="val2">second value</param>
        /// <param name="operation">type of operation</param>
        /// <returns></returns>
        static Double Calculate(Double val1, Double val2, Operation operation) {
            switch (operation) {
                case Operation.PLUS:
                    return Sum(val1, val2);
                case Operation.MINUS:
                    return Subtract(val1, val2);
                case Operation.DIV:
                    return Divide(val1, val2);
                case Operation.MUL:
                    return Multiply(val1, val2);
                case Operation.MOD:
                    return Mod(val1, val2);
                case Operation.POW:
                    return Pow(val1, val2);
                default:
                    return Sum(val1, val2);
            }
        }

        static void Main(string[] args) {
            Double value1       = default(Double);
            Double value2       = default(Double);
            Operation operation = Operation.UNKNOW;

            value1 = GetValue();

            while ((operation = GetValidOperation()) != Operation.EXIT) {
                value2 = GetValue();
                value1 = Calculate(value1, value2, operation);
                ShowResult(value1);
            }
        }
    }
}
