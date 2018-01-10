using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Child
    {
        #region fields:

        private readonly string id;
        private string firstName;
        private string LastName;
        private readonly string motherId;
        private readonly DateTime birthday;
        private bool specialNeeds;
        private string infoSpecialNeeds; //include note about the problems of the child
        #endregion

        #region properties:
        public string Id { get { return id; } }
        public string FirstName { get { return firstName; } set { firstName = value; } }
        public string MotherId { get { return motherId; } }
        public DateTime Birthday { get { return birthday; } }
        public bool SpecialNeeds { get { return specialNeeds; } set { specialNeeds = value; } }
        public string InfoSpecialNeeds { get { return infoSpecialNeeds; } set { infoSpecialNeeds = value; } }
        #endregion

        #region functions:
        public Child(string ID, string FN,string LN, string MID, DateTime birth, bool SN, string ISN)
        {
            if (!MyFunctions.CheckID(ID))
                throw new Exception("Invalid ID");
            if (!MyFunctions.CheckName(FN))
                throw new Exception("Invalid name");
            if (!MyFunctions.CheckID(MID))
                throw new Exception("Invalid name");
            if (!MyFunctions.CheckDatePast(birth))
                throw new Exception("Invalid date");
            id = ID;
            firstName = FN.Trim();//DELETE spare space
            LastName = LN.Trim();//DELETE spare space
            motherId = MID;
            birthday = birth;
            specialNeeds = SN;
            ISN = ISN.Trim();//DELETE spare space
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
