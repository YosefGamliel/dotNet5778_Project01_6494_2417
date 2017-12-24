using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    class MyFunctions
    {
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
        public static bool CheckName(string Name)
        {
            bool flag = true;
            foreach (char item in Name)
            {
                if (!((item < 'z' && item > 'a') || (item < 'Z' && item > 'A') || (item == ' ')))
                    flag = false;
            }
            return flag;
        }
        public static bool CheckDatePast(DateTime date)
        {
            return (date < DateTime.Now);
        }
        public static bool CheckContract(DateTime end, DateTime start)
        {
            
         
            return ((end > start) && (start >= DateTime.Now));
        }
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
        public static bool CheckArraySize(int[,] workHours, bool[] workDays)
        {
            return (workHours.GetLength(0) == 6 && workHours.GetLength(1) == 2 && workDays.GetLength(0) == 6);
        }
        public static bool CheckNanny(DateTime birhday, int experienceYears, int maxKids, int minAge, int maxAge, 
            float hourSalary, float monthSalary)
        {
            if ((DateTime.Now.Year - birhday.Year - 18) < experienceYears || maxKids < 1 || minAge < 3 || minAge > maxAge 
                || hourSalary < 0 || hourSalary < 0)//כי היא יכולה לעבוד מגיל 18
                return false;//יותר שנות ניסיון ממה שהיא יכולה
            return true;
        }
    }
}
