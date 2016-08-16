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
    class Calculator {
        public delegate void CalculateEventHandler(
            object sender,
            CalculateEventArgs args
        );

        public void DoCalculate(CalculateEventArgs args) {
            if (CalculateEvent != null)
                CalculateEvent(this, args);
        }

        public void ClearCalculateEventListeners() {
            CalculateEvent = null;
        }

        public event CalculateEventHandler CalculateEvent;
    }
}
