using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    class Child : Person
    {
        //fields:
        private int motherId;
        private bool specialNeeds;
        private string infoSpecialNeeds; //include note about the problems of the child
        //properties:
        public int MotheId { get { return motherId; } set { motherId = value; } }
        public bool SpecialNeeds { get { return specialNeeds; } set { specialNeeds = value; } }
        public string InfoSpecialNeeds { get { return infoSpecialNeeds; } set { infoSpecialNeeds = value; } }
    }
}
