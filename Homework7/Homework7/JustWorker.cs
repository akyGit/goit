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
    class JustWorker : Worker {
        public JustWorker() {
            workHours = 0;
            overtime  = 0;
        }

        public override Double GetSalary() {
            PromptUser();
            return CalculateSalary();
        }

        protected override void AddBonusHours(Int32 value) {
            const Int32 BONUS_FACTOR = 4;

            workHours += (value * BONUS_FACTOR);
        }

        private Double CalculateSalary() {
            Double salary = pricePerHour * 
                            (workHours + overtime * 4) * 
                            (1 + experience * EXP_FACTOR);

            return salary;
        }

        private void PromptUser() {
            promptUserExperienceAndPrice();

            workHours = Tools.DisplayInviteAndGetValidNumber(
                "Please, enter your work hours [0-200]: ", 0, 200
            );

            AddBonusHours(Tools.DisplayInviteAndGetValidNumber(
                "Please, enter your bonus hours [0-50]: ", 0, 50
            ));

            overtime = Tools.DisplayInviteAndGetValidNumber(
                "Please, enter overtime hours [0-200]: ", 0, 200
            );
        }

        protected Double workHours;
        private   Int32  overtime;

        private const Int32 OVERTIME_FACTOR = 4;
    }

    sealed class InternJustWorker : JustWorker {
        protected override void AddBonusHours(Int32 value) {
            const Double BONUS_FACTOR = 1.5;

            workHours += (value * BONUS_FACTOR);
        }
    }
}
