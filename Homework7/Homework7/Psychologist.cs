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
    class Psychologist : Worker {
        public Psychologist() {
            workHours      = 0;
            patientsNumber = 0;
        }

        public override Double GetSalary() {
            PromptUser();
            return CalculateSalary();
        }

        protected override void AddBonusHours(Int32 value) {
            const Int32 BONUS_FACTOR = 2;

            workHours += (value * BONUS_FACTOR);
        }

        private void PromptUser() {
            promptUserExperienceAndPrice();

            workHours = Tools.DisplayInviteAndGetValidNumber(
                "Please, enter your work hours [0-200]: ", 0, 200
            );

            AddBonusHours(Tools.DisplayInviteAndGetValidNumber(
                "Please, enter your bonus hours [0-50]: ", 0, 50
            ));

            patientsNumber = Tools.DisplayInviteAndGetValidNumber(
                "Please, enter patients number [0-1000]: ", 0, 1000
            );
        }

        private Double CalculateSalary() {
            Double salary = pricePerHour * 
                            workHours * 
                            (1 + experience     * EXP_FACTOR) *
                            (1 + patientsNumber * PATIENT_FACTOR);

            return salary;
        }

        protected Double workHours;
        private   Int32  patientsNumber;

        private const Double PATIENT_FACTOR = 0.2;
    }

    sealed class InternPsychologist : Psychologist {
        protected override void AddBonusHours(Int32 value) {
            const Double BONUS_FACTOR = 1.5;

            workHours += (value * BONUS_FACTOR);
        }
    }
}
