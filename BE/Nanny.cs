using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Nanny
    {
        #region fields:
        private readonly string id;
        private string lastName;
        private string firstName;
        private string phoneNumber;
        private string address;
        private readonly DateTime birthday;
        private bool elevator;
        private int floorBuilding;
        private int experienceYears;
        private int maxKids;
        private int minAge;
        private int maxAge;
        private bool hourlyRate;//(האם מאפשרת תעריף לפי שעה(אמת זה לפי שעה  
        private float hourSalary;
        private float monthSalary;
        private bool[] workDays;
        private TimeSpan[,] workHours;
        private bool vacationDaysITE; //if it's true - she gets her vacation days according to ITE (Ministry
        // of Industry, Trade and Employment), if it's false - she gets according to the Ministry of Education.
        private string recommendations;
        private int numOfKids;
        #endregion
        #region properties:
        public string Id { get { return id; } }
        public string LastName { get { return lastName; } set { lastName = value; } }
        public string FirstName { get { return firstName; } set { firstName = value; } }
        public string PhoneNumber { get { return phoneNumber; } set { phoneNumber = value; } }
        public string Address { get { return address; } set { address = value; } }
        public DateTime Birthday { get{ return birthday; }}
        public bool Elevator { get { return elevator; } set { elevator = value; } }
        public int FloorBuilding { get { return floorBuilding; } set { floorBuilding = value; } }
        public int ExperienceYears { get { return experienceYears; } set { experienceYears = value; } }
        public int MaxKids { get { return maxKids; } set { maxKids = value; } }
        public int MinAge { get { return minAge; } set { minAge = value; } }
        public int MaxAge { get { return maxAge; } set { maxAge = value; } }
        public bool HourlyRate { get { return hourlyRate; } set { hourlyRate = value; } }
        public float HourSalary { get { return hourSalary; } set { hourSalary = value; } }
        public float MonthSalary { get { return monthSalary; } set { monthSalary = value; } }
        public bool[] WorkDays { get { return workDays; } set { workDays = value; } }
        public TimeSpan[,] WorkHours { get { return workHours; } set { workHours = value; } }
        public bool VacationDaysITE { get { return vacationDaysITE; } set { vacationDaysITE = value; } }
        public string Recommendations { get { return recommendations; } set { recommendations = value; } }
        public int NumOfKids { get { return numOfKids; } set { numOfKids = value; } }
        #endregion
        #region functions:
        public Nanny(string ID, string LN, string FN, string PN, string addr, DateTime birth, bool elev, int FB, int EY, int MK,
            int MinA, int MaxA, bool HR, float HS, float MS, bool[] WD, TimeSpan[,] WH, bool VD, string recomm)
        {
            if (!MyFunctions.CheckID(ID))
                throw new Exception("Invalid ID");
            if (!MyFunctions.CheckName(LN))
                throw new Exception("Invalid name");
            if (!MyFunctions.CheckName(FN))
                throw new Exception("Invalid name");
            if (!MyFunctions.CheckPhoneNumber(PN))
                throw new Exception("Invalid phone number");
            if (!MyFunctions.CheckAddress(addr))
                throw new Exception("Invalid address");
            if (!MyFunctions.CheckDatePast(birth))
                throw new Exception("Invalid date");
            if (!MyFunctions.CheckArraySize(WH, WD))
                throw new Exception("Invalid arrays sizes");
            if (!MyFunctions.CheckNanny(birth, EY, MK, MinA, MaxA, HS, MS))
                throw new Exception("Invalid ages or invalid salaries");
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
            workHours = new TimeSpan[6, 2];
            workHours = WH;
            vacationDaysITE = VD;
            recommendations = recomm;
            numOfKids = 0;
        }
        public Nanny(Nanny nanny)
        {
            if (!MyFunctions.CheckID(nanny.Id))
                throw new Exception("Invalid ID");
            if (!MyFunctions.CheckName(nanny.LastName))
                throw new Exception("Invalid name");
            if (!MyFunctions.CheckName(nanny.FirstName))
                throw new Exception("Invalid name");
            if (!MyFunctions.CheckPhoneNumber(nanny.PhoneNumber))
                throw new Exception("Invalid phone number");
            if (!MyFunctions.CheckAddress(nanny.Address))
                throw new Exception("Invalid address");
            if (!MyFunctions.CheckDatePast(nanny.Birthday))
                throw new Exception("Invalid date");
            if (!MyFunctions.CheckArraySize(nanny.WorkHours, nanny.WorkDays))
                throw new Exception("Invalid arrays sizes");
            if (!MyFunctions.CheckNanny(nanny.Birthday, nanny.ExperienceYears, nanny.MaxKids, nanny.MinAge, nanny.MaxAge, nanny.HourSalary, nanny.MonthSalary))
                throw new Exception("Invalid ages or invalid salaries");
            id = nanny.Id;
            lastName = nanny.LastName;
            firstName = nanny.FirstName;
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
            workHours = new TimeSpan[6, 2];
            workHours = WH;
            vacationDaysITE = VD;
            recommendations = recomm;
            numOfKids = 0;
        }

        public Nanny()
        {
        }

        public override string ToString()
        {
            string str1 = null, str2 = null, str3 = null, WH = "The hours she works each day:", WORK = "Days when she works: ";
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
                WH += ("\n" + ((DaysOfWeek)i).ToString() + "- Beginning time: " + workHours[i, 0].ToString() + "End time: " + workHours[i, 1].ToString());
                if (vacationDaysITE)
                    str3 = "gets her vacation days according to the Ministry of Industry, Trade and Employment";
                else str3 = "gets her vacation days according to the Ministry of Education";
            }
            return "Id: " + id + "\nFirst name: " + firstName + "\nLast name: " + lastName + "\nPhone number: " + phoneNumber
                + "\nAddress: " + address + "\nBirthday: " + birthday + "\nElevator in the building: " + str1 + "\nFloor in the building: "
                + floorBuilding + "\nExperience years: " + experienceYears + "\nMaximum of kids: " + maxKids + "\nAges: from age " + minAge +
                " months to age " + maxAge + " months\nHourly rate: " + str2 + "\nMonth salary: " + monthSalary + "\n" + WORK + "\n" + WH + "\n"
                + str3 + "\nRecommendations" + recommendations + "\nNum of kids: " + numOfKids;
        }
        #endregion
    }

}
