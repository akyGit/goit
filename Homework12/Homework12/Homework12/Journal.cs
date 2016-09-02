/*
 * Author: Viktor Matyniuk
 * Date: 1 September, 2016
 * Description: homework 12 (goit)
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework12 {
    [Serializable]
    class Journal {
        public Journal() {
            _pupils = new List<Pupil>();
        }

        public void AddPupil(Pupil pupil) {
            _pupils.Add(pupil);
        }

        public Boolean AddSubject(String name, String subjectName, Int32 subjectMark) {
            Pupil foundPupil = _pupils.Find(item => item.Name == name);

            if (foundPupil == null)
                return false;

            foundPupil.Subjects[subjectName] = subjectMark;
            return true;
        }

        public Int32 GetAverageScore(String name) {
            Pupil foundPupil = _pupils.Find(item => item.Name == name);

            if (foundPupil == null)
                return -1;

            return foundPupil.GetAverageScore();
        }

        public void ShowMarksByStartingAge(Int32 age) {
            Boolean isEmpty = true;

            foreach (Pupil pupil in _pupils) {
                if (pupil.Age > age) {
                    pupil.ShowMarks();
                    isEmpty = false;
                }
            }

            if(isEmpty)
                Console.WriteLine("Pupils don't found");
        }

        public void ShowPupils() {
            foreach(Pupil pupil in _pupils)
                Console.WriteLine("Name: {0}; Age: {1}", pupil.Name, pupil.Age);

            if(_pupils.Count == 0)
                Console.WriteLine("Empty journal");
        }

        public void ShowPupilsMarks() {
            ShowMarksByStartingAge(Int32.MinValue);
        }

        private List<Pupil> _pupils = new List<Pupil>();
    }
}
