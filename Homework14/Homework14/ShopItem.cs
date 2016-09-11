/*
 * Author: Viktor Matyniuk
 * Date: 10 September, 2016
 * Description: homework 14 (goit)
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework14 {
    class ShopItem {
        public ShopItem() { }

        public Int32  Id     { get; set; }
        public String Name   { get; set; }
        public Double Price  { get; set; }
        public Int32  Amount { get; set; }

        public Int32 Discount {
            get {
                return _discount;
            }
            set {
                if(value >= 0 && value <= 100)
                    _discount = value;
            }
        }

        public Double Summary {
            get {
                Double result = this.Price * this.Amount;
                result -= result * (Discount / (Double)100);
                return result;
            }
        }

        private Int32 _discount = 0;
    }
}