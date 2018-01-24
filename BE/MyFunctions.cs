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
        public static bool CheckArraySize1(bool[] workDays)
        {
            return (workDays.GetLength(0) == 6);
        }
        public static bool CheckArraySize2(TimeSpan[,] workHours)
        {
            return (workHours.GetLength(0) == 6 && workHours.GetLength(1) == 2);
        }
        public static bool CheckMaxKids(int maxKids)
        {
            return !(maxKids < 1);
        }
        public static bool CheckMinAge(int minAge)
        {
            return !(minAge < 3);
        }
        public static bool CheckHourSalary(float hourSalary)
        {
            return !(hourSalary < 0);
        }
        public static bool CheckMonthSalary(float monthSalary)
        {
            return !(monthSalary < 0);
        }
    }
}


