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
    class Guard : Worker {
        public Guard() {
            workHoursDay   = 0;
            workHoursNight = 0;
        }

        public override Double GetSalary() {
            PromptUser();
            return CalculateSalary();
        }

        protected override void AddBonusHours(Int32 value) {
            const Int32 BONUS_FACTOR_DAY   = 2;
            const Int32 BONUS_FACTOR_NIGHT = 3;

            workHoursDay   += (value * BONUS_FACTOR_DAY);
            workHoursNight += (value * BONUS_FACTOR_NIGHT);
        }

        private void PromptUser() {
            promptUserExperienceAndPrice();

            workHoursDay = Tools.DisplayInviteAndGetValidNumber(
                "Please, enter your work hours at day [0-200]: ", 0, 200
            );

            workHoursNight = Tools.DisplayInviteAndGetValidNumber(
                "Please, enter your work hours at night [0-200]: ", 0, 200
            );

            AddBonusHours(Tools.DisplayInviteAndGetValidNumber(
                "Please, enter your bonus hours [0-50]: ", 0, 50
            ));
        }

        private Double CalculateSalary() {
            Double workHours = workHoursDay + 
                              (workHoursNight * NIGHT_HOURS_FACTOR);

            Double salary    = pricePerHour *
                               workHours *
                               (1 + experience * EXP_FACTOR);

            return salary;
        }

        protected Double workHoursDay;
        protected Double workHoursNight;

        private const Int32 NIGHT_HOURS_FACTOR = 2;
    }

    sealed class InternGuard : Guard {
        protected override void AddBonusHours(Int32 value) {
            const Double BONUS_FACTOR = 1.5;

            workHoursDay   += (value * BONUS_FACTOR);
            workHoursNight += (value * BONUS_FACTOR);
        }
    }
}
