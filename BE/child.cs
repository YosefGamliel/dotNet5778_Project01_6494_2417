﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    class Child
    {
        //fields:
        #region
        private int id;
        private string firstName;
        private int motherId;
        private DateTime birthday;
        private bool specialNeeds;
        private string infoSpecialNeeds; //include note about the problems of the child
        #endregion
        //properties:
        #region
        public int Id { get { return id; } set { id = value; } }
        public string FirstName { get { return firstName; } set { firstName = value; } }
        public int MotheId { get { return motherId; } set { motherId = value; } }
        public DateTime Birthday { get { return birthday; } set { birthday = value; } }
        public bool SpecialNeeds { get { return specialNeeds; } set { specialNeeds = value; } }
        public string InfoSpecialNeeds { get { return infoSpecialNeeds; } set { infoSpecialNeeds = value; } }
        #endregion
        //functions:
        #region
        public Child(int ID, string FN, int MID, DateTime birth, bool SN, string ISN)
        {
            id = ID;
            firstName = FN;
            motherId = MID;
            birthday = birth;
            specialNeeds = SN;
            infoSpecialNeeds = ISN;
        }
        public override string ToString()
        {
            string str1 = null, str2 = null;
            if (specialNeeds) str1 = "Yes";
            else str1 = "No";
            if (infoSpecialNeeds != null)
                str2 = "\nInformation about the special needs: " + infoSpecialNeeds;
            return "Id: " + id + "\nFirst name: " + firstName + "\nMother id: " + motherId +
                "\nBirthday: " + birthday + "\nSpecial needs: " + str1 + str2;
        }
        #endregion
    }
}
