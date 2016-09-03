/*
 * Author: Viktor Matyniuk
 * Date: 3 September, 2016
 * Description: homework 13 (goit)
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Homework12 {
    class Controller {
        public Controller() {
            _journal = new Journal();
        }

        public void Start() {
            while (true) {
                Console.Clear();

                Console.WriteLine("Please, what do you want to do:\n");
                Console.WriteLine(" 1.] Add pupil");
                Console.WriteLine(" 2.] Add subject");
                Console.WriteLine(" 3.] Show average mark");
                Console.WriteLine(" 4.] Show mark by starting age");
                Console.WriteLine(" 5.] Show pupils");
                Console.WriteLine(" 6.] Show pupils mark");
                Console.WriteLine(" 7.] Save to file");
                Console.WriteLine(" 8.] Load from file");
                Console.WriteLine(" 9.] Exit");

                switch (Tools.DisplayInviteAndGetValidNumber("\n Make choose: ",
                    1, 9)) {
                    case 1:
                        this.AddPupil();
                        break;
                    case 2:
                        this.AddSubject();
                        Console.ReadKey();
                        break;
                    case 3:
                        this.ShowAverageMark();
                        Console.ReadKey();
                        break;
                    case 4:
                        this.ShowMarkByStartingAge();
                        Console.ReadKey();
                        break;
                    case 5:
                        this.ShowPupils();
                        Console.ReadKey();
                        break;
                    case 6:
                        this.ShowPupilsMarks();
                        Console.ReadKey();
                        break;
                    case 7:
                        this.SaveToFile();
                        Console.ReadKey();
                        break;
                    case 8:
                        this.LoadFromFile();
                        Console.ReadKey();
                        break;
                    case 9:
                        return;
                }
            }
        }

        private void AddPupil() {
            Console.Clear();

            String pupilName = Tools.DisplayInviteAndGetString("Enter name: ");
            Int32 pupilAge = Tools.DisplayInviteAndGetValidNumber("Enter age: ", 0, 200);

            Pupil newPupil = new Pupil() {
                Name = pupilName,
                Age = pupilAge
            };

            _journal.AddPupil(newPupil);
        }

        private void AddSubject() {
            Console.Clear();

            String pupilName = Tools.DisplayInviteAndGetString("Enter name: ");
            String subjectName = Tools.DisplayInviteAndGetString("Enter subject name: ");
            Int32 subjectMark = Tools.DisplayInviteAndGetValidNumber("Enter subject mark [1-5]: ", 1, 5);

            if (!_journal.AddSubject(pupilName, subjectName, subjectMark))
                Console.WriteLine("Failed adding: pupil doesn't exist");
        }

        private void ShowAverageMark() {
            Console.Clear();

            String pupilName = Tools.DisplayInviteAndGetString("Enter name: ");
            Int32 averageScore = _journal.GetAverageScore(pupilName);

            if(averageScore == -1)
                Console.WriteLine("Failed displaying: pupil doesn't exist");
            else
                Console.WriteLine("Pupil {0} has {1} average mark", pupilName, averageScore);
        }

        private void ShowMarkByStartingAge() {
            Console.Clear();

            Int32 pupilAge = Tools.DisplayInviteAndGetValidNumber("Enter age: ", 0, 200);
            _journal.ShowMarksByStartingAge(pupilAge);
        }

        private void ShowPupils() {
            Console.Clear();
            _journal.ShowPupils();
        }

        public void ShowPupilsMarks() {
            Console.Clear();
            _journal.ShowPupilsMarks();
        }

        public void SaveToFile() {
            Console.Clear();

            BinaryFormatter binFormatter = new BinaryFormatter();

            using (Stream fStream = new FileStream("save.txt", FileMode.Create, FileAccess.Write, FileShare.None)) {
                binFormatter.Serialize(fStream, _journal);
            }

            Console.WriteLine("The saving of state is successful");
        }

        public void LoadFromFile() {
            Console.Clear();

            Journal newJournal = null;
            BinaryFormatter binFormatter = new BinaryFormatter();

            using (Stream fStream = new FileStream("save.txt", FileMode.Open, FileAccess.Read, FileShare.None)) {
                newJournal = (Journal)binFormatter.Deserialize(fStream);
            }

            _journal = newJournal;

            Console.WriteLine("The loading of state is successful");
        }

        private Journal _journal;
    }
}
