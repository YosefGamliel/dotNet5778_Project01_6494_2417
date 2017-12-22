using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    class Child
    {
        //fields:
        #region
        private readonly string id;
        private string firstName;
        private readonly string motherId;
        private readonly DateTime birthday;
        private bool specialNeeds;
        private string infoSpecialNeeds; //include note about the problems of the child
        #endregion
        //properties:
        #region
        public string Id { get { return id; } }
        public string FirstName { get { return firstName; } set { firstName = value; } }
        public string MotheId { get { return motherId; } }
        public DateTime Birthday { get { return birthday; } }
        public bool SpecialNeeds { get { return specialNeeds; } set { specialNeeds = value; } }
        public string InfoSpecialNeeds { get { return infoSpecialNeeds; } set { infoSpecialNeeds = value; } }
        #endregion
        //functions:
        #region
        public Child(string ID, string FN, string MID, DateTime birth, bool SN, string ISN)
        {
            try
            {
                if (!MyFunctions.CheckID(ID) || !MyFunctions.CheckName(FN) || !MyFunctions.CheckID(MID) ||
                    !MyFunctions.CheckDatePast(birth))
                    throw new Exception();
                id = ID;
                firstName = FN.Trim();//DELETE spare space
                motherId = MID;
                birthday = birth;
                specialNeeds = SN;
                ISN = ISN.Trim();//DELETE spare space
                infoSpecialNeeds = ISN;
            }
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
