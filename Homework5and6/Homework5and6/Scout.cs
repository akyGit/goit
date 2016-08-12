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
    class Scout {
        protected Scout() {
            this.Name       = String.Empty;
            this.sportsList = new List<Sport>();
        }

        protected Scout(String name) {
            this.Name       = name;
            this.sportsList = new List<Sport>();
        }

        public virtual bool AddSport(Sport sport) {
            sportsList.Add(sport);
            return true;
        }

        public void AddReward(Int32 sportIndex, Reward reward) {
            sportsList[sportIndex].AddReward(reward);
        }

        public void RemoveSport(Int32 index) {
            sportsList.RemoveAt(index);
        }

        public void RemoveReward(Int32 sportIndex, Int32 rewardIndex) {
            sportsList[sportIndex].RemoveReward(rewardIndex);
        }

        public Int32 SportsCount {
            get {
                return sportsList.Count;
            }
        }

        public bool IsExistSport(Sport sport) {
            foreach (Sport item in sportsList) {
                if (item.Name == sport.Name)
                    return true;
            }

            return false;
        }

        public Int32 GetPointsByIndex(Int32 index) {
            return sportsList[index].GetPointsSum();
        }

        public Int32 GetPointsSum() {
            Int32 result = 0;

            foreach (Sport item in sportsList)
                result += item.GetPointsSum();

            return result;
        }

        public Int32 GetPointsAverageCount() {
            if (SportsCount == 0)
                return 0;

            return GetPointsSum() / SportsCount;
        }

        public void DisplaySports() {
            for(Int32 i = 0; i < sportsList.Count; i++)
                Console.WriteLine("{0:D2}] {1}", i, sportsList[i].Name);
        }

        public void DisplayRewardsBySportIndex(Int32 index) {
            if (index < 0 || index >= sportsList.Count)
                return;

            sportsList[index].DispalyRewards();
        }

        public void DispalyAllRewards() {
            foreach (Sport item in sportsList) {
                Console.WriteLine("Sport: {0}", item.Name);
                item.DispalyRewards();
            }
        }

        public String Name { get; set; }

        protected List<Sport> sportsList;
    }
}
