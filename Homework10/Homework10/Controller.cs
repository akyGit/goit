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
    class Controller {
        public Controller() {
            calculator          = new Calculator();
            calculatorEventArgs = new CalculateEventArgs();
        }

        public void Start() {
            calculator.ClearCalculateEventListeners();
            calculatorEventArgs.ResetValues();

            SetArgs();
            SetEventListeners();

            calculator.DoCalculate(calculatorEventArgs);
        }

        private void SetArgs() {
            calculatorEventArgs.leftValue = 
                Tools.DisplayInviteAndGetValidNumber(
                    "Please, enter first value: ",
                    Double.MinValue,
                    Double.MaxValue
                );

            calculatorEventArgs.rightValue = 
                Tools.DisplayInviteAndGetValidNumber(
                    "Please, enter second value: ",
                    Double.MinValue,
                    Double.MaxValue
                );
        }

        private void SetEventListeners() {

            #region show menu
            Console.WriteLine("List of actions:");
            Console.WriteLine(" 1: +");
            Console.WriteLine(" 2: -");
            Console.WriteLine(" 3: /");
            Console.WriteLine(" 4: *");
            #endregion

            String userInput = Tools.DisplayInviteAndGetString(
                "Please, enter actions (as sequence of numbers): "
            );

            foreach (Char c in userInput) {
                #region selection of calculate listener (switch)
                switch (c) {
                    case '1':
                        calculator.CalculateEvent +=
                            new Calculator.CalculateEventHandler(Operations.Plus);
                        break;
                    case '2':
                        calculator.CalculateEvent +=
                            new Calculator.CalculateEventHandler(Operations.Minus);
                        break;
                    case '3':
                        calculator.CalculateEvent +=
                            new Calculator.CalculateEventHandler(Operations.Divide);
                        break;
                    case '4':
                        calculator.CalculateEvent +=
                            new Calculator.CalculateEventHandler(Operations.Multiply);
                        break;
                    default:
                        break;
                }
                #endregion
            }
        }

        private Calculator         calculator;
        private CalculateEventArgs calculatorEventArgs;
    }
}
