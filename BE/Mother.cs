using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    class Mother : Person
    {
        //fields:
        #region
        private string areaNanny;//where the mother search nanny
        private bool[] needNanny;
        private int[,] workHours;
        private string notes;//Remarks or Requirements
        #endregion
        //properties:
        #region
        public string AreaNanny { get { return areaNanny; } set { areaNanny = value; } }
        public bool[] NeedNanny { get { return needNanny; } set { needNanny = value; } }
        public string Notes { get { return notes; } set { notes = value; } }
        public int[,] WorkHours { get { return workHours; } set { workHours = value; } }
        #endregion
        //functions:
        #region
        public Mother(string area, bool[] need, int[,] hours, string nt)
        {
            areaNanny = area;
            needNanny = need;
            workHours = new int[6, 2];
            workHours = hours;
            notes = nt;
        }
        public override string ToString()
        {
            string WH = "The required hours each day:", NEED = "Days when needs a nanny: ";
            for (int i = 0; i < 6; ++i)
            {
                NEED += ((DaysOfWeek)i).ToString();
                if (needNanny[i])
                    NEED += ": Yes ";
                else
                    NEED += ": No ";
                WH += ("\n" + ((DaysOfWeek)i).ToString() + "- Beginning time: " + (workHours[i, 0] / 100) + ":"
                    + (workHours[i, 0] % 100) + "End time: " + (workHours[i, 1] / 100) + ":" + (workHours[i, 1] % 100));
            }
            return "Id: " + Id + "\nFirst name: " + FirstName + "\nLast name: " + LastName + "\nPhone number: " +
                PhoneNumber + "\nAddress: " + Address + "\nAddress of area where she search a nanny: " + areaNanny
                + "\n" + NEED + "\n" + WH + "\nNotes: " + notes;
        }
        #endregion
    }
}

