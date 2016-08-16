using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1 {
    class Program {
        static void Main(string[] args) {
            MyClass instance = new MyClass();
            MyDelegate dlg = new MyDelegate(instance.Method) + new MyDelegate(instance.Method2);

            dlg.Invoke(10);

            MyDelegate dlg2 = delegate (Int32 value) {
                return value * 10;
            };

            Console.WriteLine(dlg2.Invoke(10));

            MyDelegate dlg3 = (Int32 value) => {
                value++;
                return value;
            };

            Console.WriteLine(dlg3(44));

            Int32 b = 66;

            MyDelegate dlg4 = value => value * 100 + b;

            Console.WriteLine(dlg4.Invoke(55));
        }
    }

    class MyClass {
        public int b = 15;

        public Int32 Method(Int32 value) {
            Console.WriteLine("Value: {0} {1}", value, b);
            return value * 2;
        }

        public Int32 Method2(Int32 value) {
            Console.WriteLine("Value: {0} {1}", value, b);
            return value * 2;
        }
    }

    delegate Int32 MyDelegate(Int32 value);
}
