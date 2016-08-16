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
    class AmericanBot : Bot {
        public AmericanBot() : base() { }

        public AmericanBot(String name) : base(name) { }

        public override void Hello() {
            Console.WriteLine("Hello!");
        }

        public override void Bye() {
            Console.WriteLine("Bye...");
        }

        public override void DontUnderstand() {
            Console.WriteLine("I don't understand you");
        }

        public override void HowAreYou() {
            Console.WriteLine("How are you?");
        }

        public override void ItsGood() {
            Console.WriteLine("It's good");
        }

        public override void WhateverPhrase() {
            Console.WriteLine("Maybe something will tell?");
        }

        public override void MyNameIs() {
            Console.WriteLine("My name is {0}", Name);
        }

        public override void WhatIsYourName() {
            Console.WriteLine("What is your name?");
        }

        public override void NiceToMeetYou() {
            Console.WriteLine("Nice to meet you");
        }

        public override String GetByePhase() {
            return "bye";
        }
    }
}
