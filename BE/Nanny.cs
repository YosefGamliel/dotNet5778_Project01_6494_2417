using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Nanny
    {
        #region fields:
        private string id;
        private string lastName;
        private string firstName;
        private string phoneNumber;
        private string address;
        private DateTime birthday;
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
        public string Id
        {
            get { return id; }
            set
            {
                if (!MyFunctions.CheckID(value))
                    throw new Exception("Invalid ID");

                id = value;
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (!MyFunctions.CheckName(value))
                    throw new Exception("Invalid name");
                lastName = value;
            }
        }
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (!MyFunctions.CheckName(value))
                    throw new Exception("Invalid name");
                firstName = value;
            }
        }
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                if (!MyFunctions.CheckPhoneNumber(value))
                    throw new Exception("Invalid phone number");
                phoneNumber = value;
            }
        }
        public string Address
        {
            get { return address; }
            set
            {
                if (!MyFunctions.CheckAddress(value))
                    throw new Exception("Invalid address");
                address = value;
            }
        }
        public DateTime Birthday
        {
            get { return birthday; }
            set
            {
                if (!MyFunctions.CheckDatePast(value))
                    throw new Exception("Invalid date");
                birthday = value;
            }
        }
        public bool Elevator { get { return elevator; } set { elevator = value; } }
        public int FloorBuilding { get { return floorBuilding; } set { floorBuilding = value; } }
        public int ExperienceYears { get { return experienceYears; } set { experienceYears = value; } }
        public int MaxKids
        {
            get { return maxKids; }
            set
            {
                if (!MyFunctions.CheckMaxKids(value))
                    throw new Exception("Invalid max kids");
                maxKids = value;
            }
        }
        public int MinAge
        {
            get { return minAge; }
            set
            {
                if (!MyFunctions.CheckMinAge(value))
                    throw new Exception("Invalid min age");
                minAge = value;
            }
        }
        public int MaxAge { get { return maxAge; } set { maxAge = value; } }
        public bool HourlyRate { get { return hourlyRate; } set { hourlyRate = value; } }
        public float HourSalary
        {
            get { return hourSalary; }
            set
            {
                if (!MyFunctions.CheckHourSalary(value))
                    throw new Exception("Invalid hour salary");
                hourSalary = value;
            }
        }
        public float MonthSalary
        {
            get { return monthSalary; }
            set
            {
                if (!MyFunctions.CheckMonthSalary(value))
                    throw new Exception("Invalid month salary");
                monthSalary = value;
            }
        }
     //   [XmlIgnore]
        public bool[] WorkDays
        {
            get { return workDays; }
            set
            {
                if (!MyFunctions.CheckArraySize1(value))
                    throw new Exception("Invalid arrays sizes");
                workDays = value;
            }
        }
     //   [XmlIgnore]
        public TimeSpan[,] WorkHours
        {
            get { return workHours; }
            set
            {
                if (!MyFunctions.CheckArraySize2(value))
                    throw new Exception("Invalid arrays sizes");
                workHours = value;
            }
        }

         public string WorkDaysXml
        {
            get
            {
                if (WorkDays == null)
                    return null;
                string result = "";
                int size1 = WorkDays.Length;
                result += size1;
                for (int i = 0; i < size1; i++)
                {
                    result += "," + WorkDays[i].ToString();
                }
                return result;
            }
            set
            {
                if(value!= null&&value.Length>0)
                {
                    string[] values = value.Split(',');
                    int size = int.Parse(values[0]);
                    WorkDays = new bool[size];
                    int index = 1;
                    for (int i = 0; i < size; i++)
                    {
                        WorkDays[i] = bool.Parse(values[index++]);
                    }
                }




            }
        }
        public string workHourxml
        {
            get
            {
                if (WorkHours == null) return null;
                string result = "";
                if (WorkHours != null)
                {

                    int sizeA = WorkHours.GetLength(0);
                    int sizeB = WorkHours.GetLength(1);
                    result += "" + sizeA + "," + sizeB;
                    for (int i = 0; i < sizeA; i++)
                        for (int j = 0; j < sizeB; j++)
                            result += "," + WorkHours[i, j];
                }
                return result;
            }
            set
            {
                if (value != null && value.Length > 0)
                {
                    string[] values = value.Split(',');
                    int sizeA = int.Parse(values[0]);
                    int sizeB = int.Parse(values[1]);
                    WorkHours = new TimeSpan[sizeA, sizeB];
                    int index = 2;
                    for (int i = 0; i < sizeA; i++)
                        for (int j = 0; j < sizeB; j++)
                            WorkHours[i, j] = TimeSpan.Parse(values[index++]);
                }
            }
        }

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
            if (!MyFunctions.CheckArraySize1(WD))
                throw new Exception("Invalid arrays sizes");
            if (!MyFunctions.CheckArraySize2(WH))
                throw new Exception("Invalid arrays sizes");
            if (!MyFunctions.CheckMaxKids(MK))
                throw new Exception("Invalid max kids");
            if (!MyFunctions.CheckMinAge(MinA))
                throw new Exception("Invalid min age");
            if (!MyFunctions.CheckHourSalary(HS))
                throw new Exception("Invalid hour salary");
            if (!MyFunctions.CheckMonthSalary(MS))
                throw new Exception("Invalid month salary");
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
            workDays = new bool[6];
            workDays = WD;
            workHours = new TimeSpan[6, 2];
            workHours = WH;
            vacationDaysITE = VD;
            recommendations = recomm;
            numOfKids = 0;
        }
        public Nanny()
        {
            workDays = new bool[6];
            workHours = new TimeSpan[6, 2];
        }
        //צריך לסדר את זה אבל 
        //********חובה************
        //שהתשע תווים הראשונים יהיו של התז ללא שום תוספת 
        //או למצוא דרך לסדר את ה מחיקה ב תצוגה.
        public override string ToString()
        {
            return Id + " " + FirstName + "  " + LastName + " ";
        }
        #region
        //public override string ToString()
        //{
        //    string str1 = null, str2 = null, str3 = null, WH = "The hours she works each day:", WORK = "Days when she works: ";
        //    if (elevator) str1 = "Yes";
        //    else str1 = "No";
        //    if (hourlyRate) str2 = "Yes";
        //    else str2 = "No";
        //    //for (int i = 0; i < 6; ++i)
        //    //{
        //    //    WORK += ((DaysOfWeek)i).ToString();
        //    //    if (workDays[i])
        //    //        WORK += ": Yes ";
        //    //    else
        //    //        WORK += ": No ";
        //    //    WH += ("\n" + ((DaysOfWeek)i).ToString() + "- Beginning time: " + workHours[i, 0].ToString() + "End time: " + workHours[i, 1].ToString());
        //    //    if (vacationDaysITE)
        //    //        str3 = "gets her vacation days according to the Ministry of Industry, Trade and Employment";
        //    //    else str3 = "gets her vacation days according to the Ministry of Education";
        //    //}
        //    return "Id: " + id + "\nFirst name: " + firstName + "\nLast name: " + lastName + "\nPhone number: " + phoneNumber
        //        + "\nAddress: " + address + "\nBirthday: " + birthday + "\nElevator in the building: " + str1 + "\nFloor in the building: "
        //        + floorBuilding + "\nExperience years: " + experienceYears + "\nMaximum of kids: " + maxKids + "\nAges: from age " + minAge +
        //        " months to age " + maxAge + " months\nHourly rate: " + str2 + "\nMonth salary: " + monthSalary + "\n" + WORK + "\n" + WH + "\n"
        //        + str3 + "\nRecommendations" + recommendations + "\nNum of kids: " + numOfKids;
        //}
        #endregion
        #endregion
    }      

}
