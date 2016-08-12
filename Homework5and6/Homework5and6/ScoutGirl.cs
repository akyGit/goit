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
    class ScoutGirl : Scout {
        public static readonly String[] girlsSports = {
            "volleyball",
            "tennis",
            "dancing",
            "gymnastics"
        };

        public static void DisplayGirlSports() {
            for (Int32 i = 0; i < girlsSports.Length; i++)
                Console.WriteLine("{0,2}). {1}", i, girlsSports[i]);
        }

        public ScoutGirl() { }
        public ScoutGirl(String name) : base(name) { }

        public override bool AddSport(Sport sport) {
            if (!IsGirlsSport(sport))
                return false;

            if (IsExistSport(sport)) {
                Console.WriteLine("This kind of sport already exists");
                Console.ReadKey();
                return false;
            }

            sportsList.Add(sport);
            return true;
        }

        private bool IsGirlsSport(Sport sport) {
            foreach (String item in girlsSports) {
                if (sport.Name == item)
                    return true;
            }

            return false;
        }
    }
}
