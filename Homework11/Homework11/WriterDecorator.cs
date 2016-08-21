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
    abstract class WriterDecorator : Writer {
        public WriterDecorator(Writer writer) {
            this.writer = writer;
        }

        protected Writer writer;
    }
}
