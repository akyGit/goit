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
    public class CalculateEventArgs {
        public CalculateEventArgs(Double leftValue = 0, Double rightValue = 0) {
            this.leftValue  = leftValue;
            this.rightValue = rightValue;
        }

        public void ResetValues() {
            leftValue  = 0;
            rightValue = 0;
        }

        public Double leftValue { get; set; }
        public Double rightValue { get; set; }
    }
}
