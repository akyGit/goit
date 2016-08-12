/*
 * Author: Viktor Matyniuk
 * Date: 16 Jule, 2016
 * Description: homework 3 (goit)
 */

using System;

namespace Homework3 {
    class Program {
        const Int32 USERS_NUMBER = 7;

        static String[] UserLogins = new String[USERS_NUMBER] {
                "Viktor",
                "Aky",
                "Hugo",
                "Diablo",
                "Pussycat",
                "Toto",
                "Kiki"
            };

        static String[] UserPasswords = new String[USERS_NUMBER] {
                "1111",
                "2222",
                "3333",
                "4444",
                "5555",
                "6666",
                "7777"
            };

        static String[] UserRoles = new String[USERS_NUMBER] {
                "Admin",
                "Moderator",
                "User",
                "User",
                "User",
                "User",
                "User"
            };

        static Boolean IsExistsUser(String login) {
            for (Int32 i = 0; i < UserLogins.Length; i++) {
                if (login == UserLogins[i])
                    return true;
            }

            return false;
        }

        static Boolean IsExistsUser(String login, out Int32 userIndex) {
            for (Int32 i = 0; i < UserLogins.Length; i++) {
                if (login == UserLogins[i]) {
                    userIndex = i;
                    return true;
                }
            }

            userIndex = -1;
            return false;
        }

        static Boolean IsRigthPassword(String pwd, Int32 userIndex) {
            if (!IsValidIndex(userIndex))
                return false;

            if (pwd == UserPasswords[userIndex])
                return true;

            return false;
        }

        static Boolean IsValidIndex(Int32 userIndex) {
            if (userIndex < 0 || userIndex >= USERS_NUMBER)
                return false;

            return true;
        }

        static Int32 GetUserIndexByLogin(String login) {
            for (Int32 i = 0; i < UserLogins.Length; i++) {
                if (login == UserLogins[i])
                    return i;
            }

            return -1;
        }

        static void AdminTask() {
            Console.WriteLine("\nHello, My Admin! Information on request:");

            for (Int32 i = 0; i < USERS_NUMBER; i++)
                Console.WriteLine("User login: {0}\nUser password: {1}\nUser role: {2}\n", 
                        UserLogins[i], UserPasswords[i], UserRoles[i]);
        }

        static void ModeratorTask() {
            Console.WriteLine("\nHello, Moderator! Information on request:");
            Console.WriteLine("Users number: {0}", USERS_NUMBER);
        }

        static void UserTask() {
            Int32 result = 0;

            Console.WriteLine("\nHey, User! Information on request: ");

            Console.Write("User with role \"User\": ");
            for (Int32 i = 0; i < USERS_NUMBER; i++) {
                if (UserRoles[i] == "User") {
                    Console.Write("{0}, ", UserLogins[i]);
                    result++;
                }
            }

            Console.WriteLine("\nCommon amount of users with role \"User\": {0}", result);
        }

        static void MakeTaskByUserIndex(Int32 userIndex) {
            if (!IsValidIndex(userIndex))
                return;

            switch (UserRoles[userIndex]) {
                case "Admin":
                    AdminTask();
                    break;
                case "Moderator":
                    ModeratorTask();
                    break;
                case "User":
                    UserTask();
                    break;
                default:
                    Console.WriteLine("I don't know what I can show you. Mmmrrrggglll");
                    break;
            };
        }

        static void Main(string[] args) {
            const Int32 ATTEMPTS_NUMBER = 3;

            String login     = String.Empty;
            String pwd       = String.Empty;
            Int32  userIndex = default(Int32);

            Console.WriteLine(login);

            Console.Write("Please, enter login: ");
            login = Console.ReadLine();

            if (!IsExistsUser(login, out userIndex)) {
                Console.WriteLine("User does not exist! Bye bye...");
                return;
            }
            
            for (Int32 i = 0; i < ATTEMPTS_NUMBER; i++) {
                Console.Write("Please, enter your password: ");
                pwd = Console.ReadLine();

                if (IsRigthPassword(pwd, userIndex)) {
                    MakeTaskByUserIndex(userIndex);
                    break;
                }
            }

            return;
        }
    }
}
