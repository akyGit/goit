/*
 * Author: Viktor Matyniuk
 * Date: 21 August, 2016
 * Description: homework 11 (goit)
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework11 {
    class SquareDecorator : WriterDecorator {
        public SquareDecorator(Writer writer) : base(writer) { }

        public override void Write(String msg, Boolean toFile) {
            Double digit = Double.Parse(msg);
            Console.WriteLine(digit * digit);
            writer.Write(msg, toFile);
        }
    }
}
