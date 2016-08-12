/*
 * Author: Viktor Matyniuk
 * Date: 14 Jule, 2016
 * Description: homework 2.1 (goit)
 */

using System;

namespace Homework2_2 {

    class Program {
        static System.Double printMsgAndReadNumber(System.String msg) {
            System.Double result;

            Console.Write(msg);
            return Double.TryParse(Console.ReadLine(), out result) ? result : 0;
        }

        static void Main(string[] args) {
            System.Double circleRadius = printMsgAndReadNumber("Please, enter circle radius: ");
            Console.WriteLine("Area of circle is {0}", Math.PI * Math.Pow(circleRadius, 2));
            
            System.Double sphereRadius = printMsgAndReadNumber("Please, enter sphere radius: ");
            Console.WriteLine("Volume of sphere is {0}", (4.0/3.0) * Math.PI * Math.Pow(sphereRadius, 3));
            
            System.Double rectangleHeight = printMsgAndReadNumber("Please, enter rectangle height: ");
            System.Double rectangleWidth  = printMsgAndReadNumber("Please, enter rectangle width: ");
            Console.WriteLine("Area of rectangle is {0}", rectangleHeight * rectangleWidth);
            
            System.Double lengthFirstEdge   = printMsgAndReadNumber("Please, enter length of first edge parallelepiped: ");
            System.Double lengthSecondtEdge = printMsgAndReadNumber("Please, enter length of second edge parallelepiped: ");
            System.Double lengthThirdEdge   = printMsgAndReadNumber("Please, enter length of third edge parallelepiped: ");
            Console.WriteLine("Volume of parallelepiped is {0}", lengthFirstEdge * lengthSecondtEdge * lengthThirdEdge);
        }
    }
}
