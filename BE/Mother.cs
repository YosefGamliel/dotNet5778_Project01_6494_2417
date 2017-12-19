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
        public Mother(string area,bool[] need, int[,] hours,string nt)
        {
            areaNanny = area;
            needNanny = need;
            workHours = hours;
            notes = nt;
        }
        public override string ToString()
        {
            return ;
        }
        #endregion
    }
}

