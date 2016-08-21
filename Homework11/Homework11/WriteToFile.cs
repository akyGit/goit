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
using System.IO;

namespace Homework11 {
    delegate TextWriter StreamTuner(Boolean toFile);

    class WriteToFile : Writer {
        public WriteToFile(StreamTuner streamGetter) {
            getStream = streamGetter;
        }

        public override void Write(String msg, Boolean toFile) {
            TextWriter consoleStream = Console.Out;

            TextWriter textWriter = getStream(toFile);
            Console.SetOut(textWriter);
            Console.WriteLine(msg);

            Console.SetOut(consoleStream);

            if (textWriter is StreamWriter)
                textWriter.Close();
        }

        private StreamTuner getStream;
    }
}
