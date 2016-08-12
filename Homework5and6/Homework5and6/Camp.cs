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
    class Camp {
        enum Gender { BOY, GIRL }

        public Camp() {
            scoutsList = new List<Scout>();
        }

        private void AddScout(Scout scout) {
            scoutsList.Add(scout);
        }

        private Int32 ScoutsCount {
            get {
                return scoutsList.Count;
            }
        }

        private Int32 GetPointsByIndex(Int32 index) {
            return scoutsList[index].GetPointsSum();
        }

        private Int32 GetPointsSum() {
            Int32 result = 0;

            foreach (Scout item in scoutsList)
                result += item.GetPointsSum();

            return result;
        }

        private Int32 GetPointsAverageCount() {
            if (ScoutsCount == 0)
                return 0;

            return GetPointsSum() / ScoutsCount;
        }

        private bool IsNeedFilter(Gender sex, Scout scout) {
            if ((sex == Gender.BOY  && scout is ScoutGirl) ||
                (sex == Gender.GIRL && scout is ScoutBoy ))
                    return true;

            return false;
        }

        private Scout GetTheBest(Gender sex) {
            Scout result  = null;
            Int32 tmpAvrg = Int32.MinValue;

            foreach (Scout item in scoutsList) {
                if(!IsNeedFilter(sex, item))
                    if (item.GetPointsAverageCount() > tmpAvrg) {
                        result = item;
                        tmpAvrg = result.GetPointsAverageCount();
                    }
            }

            return result;
        }

        private Scout GetMostSuccessful(Gender sex) {
            Scout result = null;
            Int32 tmpSum = Int32.MinValue;

            foreach (Scout item in scoutsList) {
                if(!IsNeedFilter(sex, item))
                    if (item.GetPointsSum() > tmpSum) {
                        result = item;
                        tmpSum = result.GetPointsSum();
                    }
            }

            return result;
        }

        private Scout GetMostActive(Gender sex) {
            Scout result   = null;
            Int32 tmpCount = Int32.MinValue;

            foreach (Scout item in scoutsList) {
                if (!IsNeedFilter(sex, item))
                    if (item.SportsCount > tmpCount) {
                        result = item;
                        tmpCount = result.SportsCount;
                    }
            }

            return result;
        }

        private Scout GetMostLazy(Gender sex) {
            Scout result   = null;
            Int32 tmpCount = Int32.MaxValue;

            foreach (Scout item in scoutsList) {
                if (!IsNeedFilter(sex, item))
                    if (item.SportsCount < tmpCount) {
                        result = item;
                        tmpCount = result.SportsCount;
                    }
            }

            return result;
        }

        private void DisplayScouts() {
            for (Int32 i = 0; i < scoutsList.Count; i++) {
                Console.WriteLine(
                    "{0,2}). {1} {2}",
                    i,
                    scoutsList[i].Name,
                    scoutsList[i] is ScoutBoy ? "male" : "female"
                );
            }
        }

        private void DisplayScoutsBoy() {
            for (Int32 i = 0; i < scoutsList.Count; i++) {
                if(scoutsList[i] is ScoutBoy)
                    Console.WriteLine("{0,2}). {1} boy", i, scoutsList[i].Name);
            }
        }

        private void DisplayScoutsGirl() {
            for (Int32 i = 0; i < scoutsList.Count; i++) {
                if (scoutsList[i] is ScoutGirl)
                    Console.WriteLine("{0,2}). {1} girl", i, scoutsList[i].Name);
            }
        }

        private Int32 DisplayInviteAndGetValidNumber(String message, Int32 lowerBound, Int32 upperBound) {
            Int32 result;

            do {
                result = DisplayInviteAndGetNumber(message);
            } while (result < lowerBound || result > upperBound);

            return result;
        }

        private Int32 DisplayInviteAndGetNumber(String message) {
            Int32 result;

            do {
                Console.Write(message);
            } while (!Int32.TryParse(Console.ReadLine(), out result));

            return result;
        }

        private String DisplayInviteAndGetValidSex(String message) {
            String result = String.Empty;

            do {
                result = DisplayInviteAndGetString(message);
            } while (result != "b" && result != "g");

            return result;
        }

        private String DisplayInviteAndGetString(String message) {
            Console.Write(message);
            return Console.ReadLine();
        }

        private void AddScoutTask() {
            Console.Clear();

            String name = DisplayInviteAndGetString("Enter name: ");
            String sex  = DisplayInviteAndGetValidSex("Enter sex <b,g>: ");

            if (sex == "b")
                AddScout(new ScoutBoy(name));
            else
                AddScout(new ScoutGirl(name));
        }

        private void AddSportTask() {
            Console.Clear();

            if (ScoutsCount <= 0) {
                Console.WriteLine("You should add scouts");
                Console.ReadKey();
                return;
            }

            DisplayScouts();
            Int32 scoutChoise = DisplayInviteAndGetValidNumber("\nChoice scout: ", 0, ScoutsCount - 1);

            if (scoutsList[scoutChoise] is ScoutBoy) {
                ScoutBoy.DisplayBoySports();
                Int32 sportChoiseB = DisplayInviteAndGetValidNumber("\nChoice sport: ", 0, ScoutBoy.boysSports.Length - 1);
                scoutsList[scoutChoise].AddSport(new Sport(ScoutBoy.boysSports[sportChoiseB]));
            }
            else {
                ScoutGirl.DisplayGirlSports();
                Int32 sportChoiseG = DisplayInviteAndGetValidNumber("\nChoice sport: ", 0, ScoutGirl.girlsSports.Length - 1);
                scoutsList[scoutChoise].AddSport(new Sport(ScoutGirl.girlsSports[sportChoiseG]));
            }
        }

        private void AddRewardTask() {
            Console.Clear();

            if (ScoutsCount <= 0) {
                Console.WriteLine("You should add scouts");
                Console.ReadKey();
                return;
            }

            DisplayScouts();
            Int32 scoutChoise = DisplayInviteAndGetValidNumber("\nChoice scout: ", 0, ScoutsCount - 1);

            if (scoutsList[scoutChoise].SportsCount <= 0) {
                Console.WriteLine("You should add sports");
                Console.ReadKey();
                return;
            }

            scoutsList[scoutChoise].DisplaySports();
            Int32 sportChoise = DisplayInviteAndGetValidNumber("\nChoice sport: ", 0, scoutsList[scoutChoise].SportsCount - 1);

            Reward reward = new Reward();
            reward.Name   = DisplayInviteAndGetString("Enter name of reward: ");
            reward.Points = DisplayInviteAndGetValidNumber("Enter count of points: ", 0, 100);
            scoutsList[scoutChoise].AddReward(sportChoise, reward);
        }

        private void RemoveSportTask() {
            Console.Clear();

            if (ScoutsCount <= 0) {
                Console.WriteLine("You should add scouts");
                Console.ReadKey();
                return;
            }

            DisplayScouts();
            Int32 scoutChoise = DisplayInviteAndGetValidNumber("\nChoice scout: ", 0, ScoutsCount - 1);

            if (scoutsList[scoutChoise].SportsCount <= 0) {
                Console.WriteLine("You should add sports");
                Console.ReadKey();
                return;
            }

            scoutsList[scoutChoise].DisplaySports();

            Int32 sportChoise = DisplayInviteAndGetValidNumber("\nChoice sport: ", 0, scoutsList[scoutChoise].SportsCount - 1);
            scoutsList[scoutChoise].RemoveSport(sportChoise);
        }

        private void DisplayScoutTask() {
            Console.Clear();

            Console.WriteLine(" 0]. All");
            Console.WriteLine(" 1]. Boys");
            Console.WriteLine(" 2]. Girls");

            switch (DisplayInviteAndGetValidNumber("\nMake your choice:", 0, 2)) {
                case 0:
                    DisplayScouts();
                    Console.ReadKey();
                    break;
                case 1:
                    DisplayScoutsBoy();
                    Console.ReadKey();
                    break;
                case 2:
                    DisplayScoutsGirl();
                    Console.ReadKey();
                    break;
            }
        }

        private void CalculationsTask() {
            Console.Clear();

            Console.WriteLine(" 0]. Average score of scout");
            Console.WriteLine(" 1]. Average score of camp");
            Console.WriteLine(" 2]. The best scout");
            Console.WriteLine(" 3]. The most successful scout");
            Console.WriteLine(" 4]. The most active scout");
            Console.WriteLine(" 5]. The most lazy scout");

            switch (DisplayInviteAndGetValidNumber("\n Make your choice: ", 0, 5)) {
                case 0:
                    if (ScoutsCount <= 0) {
                        Console.WriteLine("You should add scouts");
                        Console.ReadKey();
                        return;
                    }

                    DisplayScouts();
                    Int32 scoutChoise = DisplayInviteAndGetValidNumber("\nChoice scout: ", 0, ScoutsCount - 1);
                    Console.WriteLine(
                        "Average score of scout: {0}",
                        scoutsList[scoutChoise].GetPointsAverageCount()
                    );
                    Console.ReadKey();
                    break;
                case 1:
                    Console.WriteLine("Average score of camp: {0}", GetPointsAverageCount());
                    Console.ReadKey();
                    break;
                case 2:
                    Scout bestBoy = GetTheBest(Gender.BOY);
                    Scout bestGirl = GetTheBest(Gender.GIRL);
                    Console.WriteLine(
                        "Best boy {0}; Best girl: {1}",
                        bestBoy != null ? bestBoy.Name : "unknow",
                        bestGirl != null ? bestGirl.Name : "unknow"
                    );
                    Console.ReadKey();
                    break;
                case 3:
                    Scout successfulBoy = GetMostSuccessful(Gender.BOY);
                    Scout successfulGirl = GetMostSuccessful(Gender.GIRL);
                    Console.WriteLine(
                        "The most successful boy {0}; The most successful girl: {1}",
                        successfulBoy != null ? successfulBoy.Name : "unknow",
                        successfulGirl != null ? successfulGirl.Name : "unknow"
                    );
                    Console.ReadKey();
                    break;
                case 4:
                    Scout activeBoy = GetMostActive(Gender.BOY);
                    Scout activeGirl = GetMostActive(Gender.GIRL);
                    Console.WriteLine(
                        "The most active boy {0}; The most active girl: {1}",
                        activeBoy != null ? activeBoy.Name : "unknow",
                        activeGirl != null ? activeGirl.Name : "unknow"
                    );
                    Console.ReadKey();
                    break;
                case 5:
                    Scout lazyBoy = GetMostLazy(Gender.BOY);
                    Scout lazyGirl = GetMostLazy(Gender.GIRL);
                    Console.WriteLine(
                        "The most lazy boy {0}; The most lazy girl: {1}",
                        lazyBoy != null ? lazyBoy.Name : "unknow",
                        lazyGirl != null ? lazyGirl.Name : "unknow"
                    );
                    Console.ReadKey();
                    break;
            }
        }

        public void StartCampSeason() {
            while (true) {
                Console.Clear();

                Console.WriteLine(" 0]. Add the scout");
                Console.WriteLine(" 1]. Add the sport");
                Console.WriteLine(" 2]. Add the reward");
                Console.WriteLine(" 3]. Remove the sport");
                Console.WriteLine(" 4]. Display scouts");
                Console.WriteLine(" 5]. Calculations");
                Console.WriteLine(" 6]. Exit");

                switch (DisplayInviteAndGetValidNumber("\nMake your choice: ", 0, 6)) {
                    case 0:
                        AddScoutTask();
                        break;
                    case 1:
                        AddSportTask();
                        break;
                    case 2:
                        AddRewardTask();
                        break;
                    case 3:
                        RemoveSportTask();
                        break;
                    case 4:
                        DisplayScoutTask();
                        break;
                    case 5:
                        CalculationsTask();
                        break;
                    case 6:
                        return;
                }
            }
        }

        private List<Scout> scoutsList;
    }
}
