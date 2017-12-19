using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    class Nanny : Person
    {
        //fields:
        #region
        private bool elevator;
        private int floorBuilding;
        private int experienceYears;
        private int maxKids;
        private int minAge;
        private int maxAge;
        private bool hourlyRate;
        private float hourSalary;
        private float monthSalary;
        private bool[] workDays = new bool[5];
        private DaysOfWeek[][] workHours = new DaysOfWeek[5][];
        private bool vacationDaysITE; //if it's true - she gets her vacation days according to ITE (Ministry
        // of Industry, Trade and Employment), if it's false - she gets according to the Ministry of Education.
        private string recommendations;
        #endregion
        //properties:
        #region
        public bool Elevator { get { return elevator; } set { elevator = value; } }
        public int FloorBuilding { get { return floorBuilding; } set { floorBuilding = value; } }
        public int ExperienceYears { get { return experienceYears; } set { experienceYears = value; } }
        public int MaxKids { get { return MaxKids; } set { MaxKids = value; } }
        public int MinAge { get { return minAge; } set { minAge = value; } }
        public int MaxAge { get { return maxAge; } set { maxAge = value; } }
        public bool HourlyRate { get { return hourlyRate; } set { hourlyRate = value; } }
        public float HourSalary { get { return hourSalary; } set { hourSalary = value; } }
        public float MonthSalary { get { return monthSalary; } set { monthSalary = value; } }
        public bool VacationDaysITE { get { return vacationDaysITE; } set { vacationDaysITE = value; } }
        public string Recommendations { get { return recommendations; } set { recommendations = value; } }
        #endregion
    }

}