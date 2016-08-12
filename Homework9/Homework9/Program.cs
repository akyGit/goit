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
    class Program {
        static void Main(string[] args) {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            ChatManager chatManager = new ChatManager();

            chatManager.StartChat();
        }
    }
}
