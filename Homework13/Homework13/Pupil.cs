/*
 * Author: Viktor Matyniuk
 * Date: 3 September, 2016
 * Description: homework 13 (goit)
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework12 {
    [Serializable]
    class Pupil {
        public Pupil() {
            Subjects = new Dictionary<string, int>();
        }

        public Int32 GetAverageScore() {
            Int32 sum = 0;

            foreach (Int32 item in this.GetMarks())
                sum += item;

            return sum / (Subjects.Count != 0 ? Subjects.Count : 1);
        }

        public void ShowMarks() {
            Console.WriteLine("Name: {0}", Name);

            foreach (KeyValuePair<String, Int32> item in Subjects)
                Console.WriteLine("   Subject {0}: {1} mark", item.Key, item.Value);

            if (Subjects.Count == 0)
                Console.WriteLine("   Pupil is studying nothing");
        }

        private IEnumerable GetMarks() {
            foreach (KeyValuePair<String, Int32> item in Subjects) {
                yield return item.Value;
            }

            yield break;
        }

        public String Name { get; set; }
        public Int32  Age { get; set; }
        public Dictionary<String, Int32> Subjects { get; set; }
    }
}
