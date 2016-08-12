/*
 * Author: Viktor Matyniuk
 * Date: 6 August, 2016
 * Description: homework 7 (goit)
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework7 {
    class Booker {
        public void StartWorking() {
            Worker worker = null;

            while (true) {
                Console.Clear();

                Console.WriteLine("Hello, who are you?");
                Console.WriteLine(" 1]. Doctor");
                Console.WriteLine(" 2]. Psychologist");
                Console.WriteLine(" 3]. JustWorker");
                Console.WriteLine(" 4]. Guard");
                Console.WriteLine(" 5]. Intern");
                Console.WriteLine(" 6]. Exit");

                #region selection of worker (switch)
                switch (Tools.DisplayInviteAndGetValidNumber(
                     "\nMake your choice: ", 1, 6)) {
                    case 1:
                        worker = new Doctor();
                        break;
                    case 2:
                        worker = new Psychologist();
                        break;
                    case 3:
                        worker = new JustWorker();
                        break;
                    case 4:
                        worker = new Guard();
                        break;
                    case 5:
                        worker = GetIntern();
                        break;
                    case 6:
                    default:
                        worker = null;
                        break;  
                }
                #endregion

                if (worker == null)
                    break;

                PrintSalary(worker);
                Console.ReadKey();
            }
        }

        private Worker GetIntern() {
            Console.Clear();

            Console.WriteLine("More specifically, who are you?");
            Console.WriteLine(" 1]. Doctor");
            Console.WriteLine(" 2]. Psychologist");
            Console.WriteLine(" 3]. JustWorker");
            Console.WriteLine(" 4]. Guard");

            #region selection of intern (switch)
            switch (Tools.DisplayInviteAndGetValidNumber(
                "\nMake your choice: ", 1, 4)) {
                case 1:
                    return new InternDoctor();
                case 2:
                    return new InternPsychologist();
                case 3:
                    return new InternJustWorker();
                case 4:
                    return new InternGuard();
                default:
                    return null;
            }
            #endregion
        }

        private void PrintSalary(Worker worker) {
            // instead use "is" and "as" operators, use 
            // virtual mechanism and Name property of type class
            Console.WriteLine("\n| {0}, your salary is | {1} |", 
                worker.GetType().Name, worker.GetSalary());
        }
    }
}
