using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework11 {
    class NumberSquareNumberDecorator : WriterDecorator {
        public NumberSquareNumberDecorator(Writer writer) : base(writer) { }

        public override void Write(String msg, Boolean toFile) {
            writer.Write(msg, toFile);
            Double digit = Double.Parse(msg);
            Console.WriteLine(digit * digit);
            writer.Write(msg, toFile);
        }
    }
}
