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
    class Controller {
        public Controller() {
            userInput = String.Empty;
            toFile    = false;
            isDigit   = false;
            digit     = 0;
        }

        public void Start() {
            #region user input
            userInput = Tools.DisplayInviteAndGetString(
                "Enter something <message or number>: "
            );

            isDigit = Double.TryParse(userInput, out digit);

            #region show menu and selection of destination (switch)
            Console.WriteLine("Please, choose destination: ");
            Console.WriteLine(" 1.] To file");
            Console.WriteLine(" 2.] To console");

            switch (Tools.DisplayInviteAndGetValidNumber("Make choose: ",
                1, 2)) {
                case 1:
                    toFile = true;
                    break;
                case 2:
                    toFile = false;
                    break;
            }
            #endregion
            #endregion

            setUpStreamGetter();

            WriteToFile writer = new WriteToFile(streamGetter);

            if (isDigit)
                new NumberSquareNumberDecorator(writer).Write(userInput, toFile);
            else
                writer.Write(userInput, toFile);
        }

        private void setUpStreamGetter() {
            streamGetter = (file) => {
                if (file) {
                    FileStream fs = new FileStream("output.txt", FileMode.Create);
                    StreamWriter sw = new StreamWriter(fs);
                    return sw;
                }
                else
                    return Console.Out;
            };
        }

        private String userInput;
        private Boolean toFile;
        private Boolean isDigit;
        private Double digit;

        private StreamTuner streamGetter;
    }
}
