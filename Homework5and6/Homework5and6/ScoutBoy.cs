/*
 * Author: Viktor Matyniuk
 * Date: 28 Jule, 2016
 * Description: homework 5 and 6 (goit)
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5and6 {
    class ScoutBoy : Scout {
        public static readonly String[] boysSports = {
            "football",
            "backetball",
            "hockey",
            "baseball"
        };

        public static void DisplayBoySports() {
            for (Int32 i = 0; i < boysSports.Length; i++)
                Console.WriteLine("{0,2}). {1}", i, boysSports[i]);
        }

        public ScoutBoy() { }
        public ScoutBoy(String name) : base(name) { }

        public override bool AddSport(Sport sport) {
            if (!IsBoysSport(sport))
                return false;

            if (IsExistSport(sport)) {
                Console.WriteLine("This kind of sport already exists");
                Console.ReadKey();
                return false;
            }

            sportsList.Add(sport);
            return true;           
        }

        private bool IsBoysSport(Sport sport) {
            foreach(String item in boysSports) {
                if (sport.Name == item)
                    return true;
            }

            return false;
        }
    }
}
