/*
 * Author: Viktor Matyniuk
 * Date: 23 Jule, 2016
 * File: Product.cs
 * Description: Examination Module #1 (goit)
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationModule1 {
    class Product {
        public Product() { }
        public Product(String name, Double price) {
            this.Name = name;
            this.Price = price;
        }

        public String Name { get; set; }
        public Double Price { get; set; }
    }
}
