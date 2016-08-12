/*
 * Author: Viktor Matyniuk
 * Date: 28 Jule, 2016
 * Description: homework 5 and 6 (goit)
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5and6 {
    class Reward {
        public Reward() {
            this.Name   = String.Empty;
            this.Points = 0;
        }

        public Reward(String name, Int32 points) {
            this.Name   = name;
            this.Points = points;
        }

        public String Name { get; set; }
        public Int32  Points { get; set; }
    }
}
