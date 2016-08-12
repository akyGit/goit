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
    abstract class Worker {
        public Worker() {
            experience   = 0;
            pricePerHour = 0;
        }

        public    abstract Double GetSalary();
        protected abstract void   AddBonusHours(Int32 value);

        protected void promptUserExperienceAndPrice() {
            experience = Tools.DisplayInviteAndGetValidNumber(
                "Please, enter your experience [0-70] (years): ", 0, 70
            );

            pricePerHour = Tools.DisplayInviteAndGetValidNumber(
                "Please, enter your price per hour [2-50]: ", 2, 50
            );
        }

        protected Int32 experience;
        protected Int32 pricePerHour;

        protected const Double EXP_FACTOR = 0.1; // 10% per year
    }
}
