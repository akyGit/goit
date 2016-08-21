using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework11 {
    abstract class Writer {
        public Writer() { }
        
        public abstract void Write(String msg, Boolean toFile);
    }
}
