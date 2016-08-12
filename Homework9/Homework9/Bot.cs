/*
 * Author: Viktor Matyniuk
 * Date: 11 August, 2016
 * Description: homework 9 (goit)
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework9 {
    abstract class Bot {
        public Bot() {
            this.Name = "Default";
        }

        public Bot(String name) {
            this.Name = name;
        }

        public abstract void Hello();
        public abstract void Bye();
        public abstract void DontUnderstand();
        public abstract void HowAreYou();
        public abstract void ItsGood();
        public abstract void WhateverPhrase();
        public abstract void MyNameIs();
        public abstract void WhatIsYourName();
        public abstract void NiceToMeetYou();

        public String Name { get; set; }
    }
}
