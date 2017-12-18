using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    class Mother : Person
    {

        private string areaBabysitter;//where the mother search baby sitter
        private bool[] needBabysitter = new bool[7];   //need the baby sitter
        private DayOfWeek[][] workHours = new DayOfWeek[6][];
        private string note;//Remarks or Requirements
    }
}

