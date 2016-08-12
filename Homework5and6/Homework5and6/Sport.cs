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
    class Sport {
        public Sport() {
            this.Name        = String.Empty;
            this.rewardsList = new List<Reward>();
        }

        public Sport(String name) {
            this.Name        = name;
            this.rewardsList = new List<Reward>();
        }

        public void AddReward(Reward reward) {
            rewardsList.Add(reward);
        }

        public void RemoveReward(Int32 index) {
            rewardsList.RemoveAt(index);
        }

        public Int32 RewardsCount {
            get {
                return rewardsList.Count;
            }
        }

        public Int32 GetPointsByIndex(Int32 index) {
            return rewardsList[index].Points;
        }

        public Int32 GetPointsSum() {
            Int32 result = 0;

            foreach (Reward item in rewardsList)
                result += item.Points;

            return result;
        }

        public Int32 GetPointsAverageCount() {
            if (RewardsCount == 0)
                return 0;

            return GetPointsSum() / RewardsCount;
        }

        public void DispalyRewards() {
            for (Int32 i = 0; i < rewardsList.Count; i++)
                Console.WriteLine(
                    "{0:D2}] Name: {1}; Points: {2}", 
                    i, 
                    rewardsList[i].Name, 
                    rewardsList[i].Points
                );
        }

        public String Name { get; set; }
        private List<Reward> rewardsList;
    }
}
