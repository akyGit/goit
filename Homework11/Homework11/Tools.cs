using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework11 {
    static class Tools {
        static public String DisplayInviteAndGetString(String message) {
            Console.Write(message);
            return Console.ReadLine();
        }

        static public Int32 DisplayInviteAndGetNumber(String message) {
            Int32 result;

            do {
                Console.Write(message);
            } while (!Int32.TryParse(Console.ReadLine(), out result));

            return result;
        }

        static public Int32 DisplayInviteAndGetValidNumber(
            String message,
            Int32 lowerBound,
            Int32 upperBound
        ) {
            Int32 result;

            do {
                result = DisplayInviteAndGetNumber(message);
            } while (result < lowerBound || result > upperBound);

            return result;
        }
    }
}
