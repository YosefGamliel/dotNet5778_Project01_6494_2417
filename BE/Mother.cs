using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    class Mother : Person
    {
        //fields:
        #region
        private string areaBabysitter;//where the mother search baby sitter
        private bool[] needBabysitter;   //need the baby sitter
        private int[,] workHour;
        private string note;//Remarks or Requirements
        #endregion
        //properties:
        #region
        public string AreaBabysitter { get { return areaBabysitter; } set { areaBabysitter = value; } }
        public bool[] NeedBabysitter { get { return needBabysitter; } set { needBabysitter = value; } }
        public string Note { get { return note; } set { note = value; } }
        public int[,] WorkHour { get { return workHour; } set { workHour = value; } }
        //functions:
    }
}

