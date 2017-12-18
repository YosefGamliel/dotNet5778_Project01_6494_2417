using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    class Mother : Person
    {

        private string areaBabysitter;//where the mother search baby sitter
        private bool[] needBabysitter = new bool[5];   //need the baby sitter
        DayOfWeek[][] WorkHour = new DayOfWeek[5][];
        private string note;//Remarks or Requirements
        public string AreaBabysitter { get { return areaBabysitter;} set { areaBabysitter = value; } }
        public bool[] NeedBabysitter { get { return needBabysitter; } set { needBabysitter = value; } }
        private string Note { get { return note; } set { note = value; } }
    
    }
}

