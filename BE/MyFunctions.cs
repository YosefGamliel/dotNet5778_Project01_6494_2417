using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    class MyFunctions
    {
        /// <summary>
        /// check if the ID is valid
        /// (doesn't include char ,but only 9 digits)
        /// </summary>
        /// <param name="strID">id</param>
        /// <returns></returns>
        public static bool CheckID(string strID)
        {
            bool flag = true;
            if (strID.Length != 9)
                return false;
            foreach (char ch in strID)
            {
                if (ch < '0' || ch > '9')
                    flag = false;
            }
            return (flag && CheckIDNo(strID));
        }
        /// <summary>
        /// Algorithm that check if the ID valid in Israel
        /// </summary>
        /// <param name="strID">id</param>
        /// <returns></returns>
        private static bool CheckIDNo(String strID)
        {

            int[] id_12_digits = { 1, 2, 1, 2, 1, 2, 1, 2, 1 };
            int count = 0;
            if (strID == null)
                return false;
            strID = strID.PadLeft(9, '0');
            for (int i = 0; i < 9; i++)
            {
                int num = Int32.Parse(strID.Substring(i, 1)) * id_12_digits[i];
                if (num > 9)
                    num = (num / 10) + (num % 10);
                count += num;
            }
            return (count % 10 == 0);
        }
        /// <summary>
        /// check if the name is valid (includes only letters or space)
        /// </summary>
        /// <param name="Name">name</param>
        /// <returns></returns>
        public static bool CheckName(string Name)
        {
            if (Name == "" || Name == null)
                return false;
            bool flag = true;
            foreach (char item in Name)
            {
                if (!((item <= 'z' && item >= 'a') || (item <= 'Z' && item >= 'A') || (item == ' ')))
                    flag = false;
            }
            return flag;
        }
        /// <summary>
        /// Checks whether this is a date from the past
        /// </summary>
        /// <param name="date">date</param>
        /// <returns></returns>
        public static bool CheckDatePast(DateTime date)
        {
            return (date < DateTime.Now);
        }
        /// <summary>
        /// check if the end of the Contract is After the Start. 
        /// </summary>
        /// <param name="end">end working date</param>
        /// <param name="start">start working date</param>
        /// <returns></returns>
        public static bool CheckContract(DateTime end, DateTime start)
        {
            return ((end > start) && (start >= DateTime.Now));
        }
        /// <summary>
        /// Check if the Phone Number is Valid 
        /// (10 digits,only Numbers)
        /// </summary>
        /// <param name="phoneNumber">phone number</param>
        /// <returns></returns>
        public static bool CheckPhoneNumber(string phoneNumber)
        {
            bool flag = true;
            if (phoneNumber.Length != 10)
                return false;
            foreach (char digit in phoneNumber)
            {
                if (digit < '0' || digit > '9')
                    flag = false;
            }
            return flag;
        }
        /// <summary>
        /// check that the Format of the address suitable to 
        /// Google Maps Format (two ',')
        /// </summary>
        /// <param name="address">address</param>
        /// <returns></returns>
        public static bool CheckAddress(string address)
        {
            int count = 0;
            foreach (char ch in address)
            {
                if (ch == ',')
                    count++;
            }
            return (count == 2);
        }
        /// <summary>
        /// check that it's only six days of work
        /// </summary>
        /// <param name="workDays">array of work days</param>
        /// <returns></returns>
        public static bool CheckArraySize1(bool[] workDays)
        {
            return (workDays.GetLength(0) == 6);
        }
        /// <summary>
        /// check that it's only six days of work and have start time and end time
        /// </summary>
        /// <param name="workHours">array of work hours</param>
        /// <returns></returns>
        public static bool CheckArraySize2(TimeSpan[,] workHours)
        {
            return (workHours.GetLength(0) == 6 && workHours.GetLength(1) == 2);
        }
        /// <summary>
        /// check that maximun of kids is bigger than 0
        /// </summary>
        /// <param name="maxKids">maximun of kids</param>
        /// <returns></returns>
        public static bool CheckMaxKids(int maxKids)
        {
            return !(maxKids < 1);
        }
        /// <summary>
        /// check that the minimun Age is bigger than three month
        /// </summary>
        /// <param name="minAge"></param>
        /// <returns></returns>
        public static bool CheckMinAge(int minAge)
        {
            return !(minAge < 3);
        }
        /// <summary>
        /// check if the salary per hour is bigger than 0
        /// </summary>
        /// <param name="hourSalary">salary per hour</param>
        /// <returns></returns>
        public static bool CheckHourSalary(float hourSalary)
        {
            return !(hourSalary < 0);
        }
        /// <summary>
        /// check if the salary per month is bigger than 0
        /// </summary>
        /// <param name="monthSalary">salary per month</param>
        /// <returns></returns>
        public static bool CheckMonthSalary(float monthSalary)
        {
            return !(monthSalary < 0);
        }
    }
}


