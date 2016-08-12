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
        public ChatManager() {
            ukrBot = new UkrainianBot();
            rusBot = new RussianBot();
            usaBot = new AmericanBot();
        }

        public void StartChat() {
            Bot bot = null;

            Console.WriteLine("Please, choose language: ");
            Console.WriteLine(" 1.] Ukrainian");
            Console.WriteLine(" 2.] Russian");
            Console.WriteLine(" 3.] English");

            #region selection of bot nationality (switch)
            switch (Tools.DisplayInviteAndGetValidNumber("Make your choice: ", 
                1, 3)) {
                case 1:
                    bot = ukrBot;
                    break;
                case 2:
                    bot = rusBot;
                    break;
                case 3:
                    bot = usaBot;
                    break;
                default:
                    bot = usaBot;
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
            bot.WhateverPhrase();
            InputImitation();

            bot.DontUnderstand();
            bot.Bye();
            InputImitation();
        }

        private void InputImitation() {
            Console.Write("> ");
            Console.ReadLine();
        }

        private UkrainianBot ukrBot;
        private RussianBot   rusBot;
        private AmericanBot  usaBot;
    }
}
