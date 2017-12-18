using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    class Mother : Person
    {
        //fields:
        private string areaBabysitter;//where the mother search baby sitter
        private bool[] needBabysitter = new bool[5];   //need the baby sitter
        private DaysOfWeek[][] workHour = new DaysOfWeek[5][];
        private string note;//Remarks or Requirements
        //properties:
        public string AreaBabysitter { get { return areaBabysitter;} set { areaBabysitter = value; } }
        public bool[] NeedBabysitter { get { return needBabysitter; } set { needBabysitter = value; } }
        public string Note { get { return note; } set { note = value; } }
        public DaysOfWeek[][] WorkHour
        {
            get { return workHour; }
            /*set
            {
                for (int i=0;i<5;++i)
                    
            }*/
        }
        //functions:
    }
}

