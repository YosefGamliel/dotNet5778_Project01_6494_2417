﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    class Nanny
    {
        //fields:
        #region
        private int id;
        private string lastName;
        private string firstName;
        private int phoneNumber;
        private string address;
        private DateTime birthday;
        private bool elevator;
        private int floorBuilding;
        private int experienceYears;
        private int maxKids;
        private int minAge;
        private int maxAge;
        private bool hourlyRate;
        private float hourSalary;
        private float monthSalary;
        private bool[] workDays;
        private int[,] workHours;
        private bool vacationDaysITE; //if it's true - she gets her vacation days according to ITE (Ministry
        // of Industry, Trade and Employment), if it's false - she gets according to the Ministry of Education.
        private string recommendations;
        #endregion
        //properties:
        #region
        public int Id { get { return id; } set { id = value; } }
        public string LastName { get { return lastName; } set { lastName = value; } }
        public string FirstName { get { return firstName; } set { firstName = value; } }
        public int PhoneNumber { get { return phoneNumber; } set { phoneNumber = value; } }
        public string Address { get { return address; } set { address = value; } }
        public DateTime Birthday { get { return birthday; } set { birthday = value; } }
        public bool Elevator { get { return elevator; } set { elevator = value; } }
        public int FloorBuilding { get { return floorBuilding; } set { floorBuilding = value; } }
        public int ExperienceYears { get { return experienceYears; } set { experienceYears = value; } }
        public int MaxKids { get { return MaxKids; } set { MaxKids = value; } }
        public int MinAge { get { return minAge; } set { minAge = value; } }
        public int MaxAge { get { return maxAge; } set { maxAge = value; } }
        public bool HourlyRate { get { return hourlyRate; } set { hourlyRate = value; } }
        public float HourSalary { get { return hourSalary; } set { hourSalary = value; } }
        public float MonthSalary { get { return monthSalary; } set { monthSalary = value; } }
        public bool[] WorkDays { get { return workDays; } set { workDays = value; } }
        public int[,] WorkHours { get { return WorkHours; } set { workHours = value; } }
        public bool VacationDaysITE { get { return vacationDaysITE; } set { vacationDaysITE = value; } }
        public string Recommendations { get { return recommendations; } set { recommendations = value; } }
        #endregion
        //functions:
        #region
        public Nanny(int ID, string LN, string FN,int PN,string addr, DateTime birth,bool elev,int FB,int EY,int MK,
            int MinA,int MaxA,bool HR,float HS,float MS,bool[] WD,int[,] WH,bool VD,string recomm)
        {
            id = ID;
            lastName = LN;
            firstName = FN;
            phoneNumber = PN;
            address = addr;
            birthday = birth;
            elevator = elev;
            floorBuilding = FB;
            experienceYears = EY;
            maxKids = MK;
            minAge = MinA;
            maxAge = MaxA;
            hourlyRate = HR;
            hourSalary = HS;
            monthSalary = MS;
            workDays = WD;
            workHours = new int[6, 2];
            workHours = WH;
            vacationDaysITE = VD;
            recommendations = recomm;
        }
        public override string ToString()
        {
            string str1 = null, str2 = null,str3=null, WH = "The hours she works each day:", WORK = "Days when she works: ";
            if (elevator) str1 = "Yes";
            else str1 = "No";
            if (hourlyRate) str2 = "Yes";
            else str2 = "No";
            for (int i = 0; i < 6; ++i)
            {
                WORK += ((DaysOfWeek)i).ToString();
                if (workDays[i])
                    WORK += ": Yes ";
                else
                    WORK += ": No ";
                WH += ("\n" + ((DaysOfWeek)i).ToString() + "- Beginning time: " + (workHours[i, 0] / 100) + ":"
                    + (workHours[i, 0] % 100) + "End time: " + (workHours[i, 1] / 100) + ":" + (workHours[i, 1] % 100));
                if (vacationDaysITE)
                    str3 = "gets her vacation days according to the Ministry of Industry, Trade and Employment";
                else str3 = "gets her vacation days according to the Ministry of Education";
            }
            return "Id: " + id + "\nFirst name: " + firstName + "\nLast name: " + lastName + "\nPhone number: " + phoneNumber
                + "\nAddress: " + address + "\nBirthday: " + birthday + "\nElevator in the building: " + str1 + "\nFloor in the building: "
                + floorBuilding + "\nExperience years: " + experienceYears + "\nMaximum of kids: " + maxKids + "\nAges: from age " + minAge +
                " months to age " + maxAge + " months\nHourly rate: " + str2 + "\nMonth salary: " + monthSalary + "\n" + WORK + "\n" + WH + "\n"
                + str3 + "\nRecommendations" + recommendations;
        }
        #endregion
    }
}