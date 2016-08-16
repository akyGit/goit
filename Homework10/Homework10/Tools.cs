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
    static class Tools {
        static public String DisplayInviteAndGetString(String message) {
            Console.Write(message);
            return Console.ReadLine();
        }

        static public Double DisplayInviteAndGetNumber(String message) {
            Double result;

            do {
                Console.Write(message);
            } while (!Double.TryParse(Console.ReadLine(), out result));

            return result;
        }

        static public Double DisplayInviteAndGetValidNumber(
            String message, 
            Double lowerBound, 
            Double upperBound
        ) {
            Double result;

            do {
                result = DisplayInviteAndGetNumber(message);
            } while (result < lowerBound || result > upperBound);

            return result;
        }
    }
}
