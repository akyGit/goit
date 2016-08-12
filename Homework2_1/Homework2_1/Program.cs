/*
 * Author: Viktor Matyniuk
 * Date: 14 Jule, 2016
 * Description: homework 2.1 (goit)
 */

using System;

namespace Homework2_1 {
    class Program {
        static void Main(string[] args) {
            Int64 number       = 1234567890;
            Int64 tenInPower   = 10;
            Int32 numberLength = 1;

            while (numberLength < 10 && (number / tenInPower) != 0) {
                tenInPower *= 10;
                numberLength++;
            }

            for (int i = numberLength - 1; i >= 0; i--) {
                tenInPower /= 10;
                Int64 currentNumber = (number / tenInPower) % 10;

                if ((currentNumber % 2) != 0)
                    currentNumber = ((currentNumber == 9) ? 0 : currentNumber + 1);

                Console.Write(currentNumber);
            }

            Console.WriteLine(); // for nice view in debug time
        }
    }
}
