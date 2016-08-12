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
    class RussianBot : Bot {
        public RussianBot() : base("Поумолчанию") { }

        public RussianBot(String name) : base(name) { }

        public override void Hello() {
            Console.WriteLine("Привет");
        }

        public override void Bye() {
            Console.WriteLine("Пока");
        }

        public override void DontUnderstand() {
            Console.WriteLine("Я тебя не понимаю");
        }

        public override void HowAreYou() {
            Console.WriteLine("Как дела?");
        }

        public override void WhateverPhrase() {
            Console.WriteLine("Почему спать нужно ночью?");
        }

        public override void ItsGood() {
            Console.WriteLine("Это хорошо");
        }

        public override void MyNameIs() {
            Console.WriteLine("Меня зовут {0}", Name);
        }

        public override void WhatIsYourName() {
            Console.WriteLine("Как тебя зовут?");
        }

        public override void NiceToMeetYou() {
            Console.WriteLine("Рад с тобой познакомиться");
        }
    }
}
