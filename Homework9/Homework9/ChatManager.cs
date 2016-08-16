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
    class ChatManager {
        enum Nationality { UKR = 1, RUS, USA };

        public ChatManager() { }

        public void StartChat() {
            Bot bot = null;

            Console.WriteLine("Please, choose language: ");
            Console.WriteLine(" {0}.] Ukrainian", (Int32)Nationality.UKR);
            Console.WriteLine(" {0}.] Russian",   (Int32)Nationality.RUS);
            Console.WriteLine(" {0}.] English",   (Int32)Nationality.USA);

            #region selection of bot nationality (switch)
            switch (
                (Nationality)Tools.DisplayInviteAndGetValidNumber(
                    "Make your choice: ",
                    (Int32)Nationality.UKR, 
                    (Int32)Nationality.USA
                )
            ) {
                case Nationality.UKR:
                    bot = new UkrainianBot();
                    break;
                case Nationality.RUS:
                    bot = new RussianBot();
                    break;
                case Nationality.USA:
                    bot = new AmericanBot();
                    break;
                default:
                    bot = new AmericanBot();
                    break;
            }
            #endregion

            Chat(bot);
        }

        private void Chat(Bot bot) {
            Console.Clear();

            bot.Hello();
            bot.MyNameIs();
            bot.WhatIsYourName();
            InputImitation();

            bot.NiceToMeetYou();
            bot.HowAreYou();
            InputImitation();
            bot.ItsGood();

            LittleBitInteractivity(bot);

            bot.Bye();
            InputImitation();
        }

        private void LittleBitInteractivity(Bot bot) {
            String byePhrase = bot.GetByePhase();

            bot.WhateverPhrase();
            while (UserInput().ToLower() != byePhrase.ToLower()) {
                bot.DontUnderstand();
                bot.WhateverPhrase();
            }
        }

        private void InputImitation() {
            Console.Write("> ");
            Console.ReadLine();
        }

        private String UserInput() {
            Console.Write("> ");
            return Console.ReadLine();
        }
    }
}
