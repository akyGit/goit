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
    class UkrainianBot : Bot {
        public UkrainianBot() : base("Типово") { }

        public UkrainianBot(String name) : base(name) { }

        public override void Hello() {
            Console.WriteLine("Привiт!");
        }

        public override void Bye() {
            Console.WriteLine("Бувай здоровий...");
        }

        public override void DontUnderstand() {
            Console.WriteLine("Я тебе не розумiю");
        }

        public override void HowAreYou() {
            Console.WriteLine("Як у тебе справи?");
        }

        public override void ItsGood() {
            Console.WriteLine("Це добре");
        }

        public override void WhateverPhrase() {
            Console.WriteLine("Чи можна спати коли бiгаєш?");
        }

        public override void MyNameIs() {
            Console.WriteLine("Мене звуть {0}", Name);
        }

        public override void WhatIsYourName() {
            Console.WriteLine("Як твоє iм'я?");
        }

        public override void NiceToMeetYou() {
            Console.WriteLine("Радий з тобою познайомитись");
        }
    }
}
