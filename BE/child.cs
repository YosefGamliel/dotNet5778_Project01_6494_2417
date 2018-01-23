using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Child
    {
        #region fields:

        private string id;
        private string firstName;
        private string motherId;
        private DateTime birthday;
        private bool specialNeeds;
        private string infoSpecialNeeds; //include note about the problems of the child
        #endregion

        #region properties:
        public string Id
        {
            get { return id; }
            set
            {
                if (!MyFunctions.CheckID(value))
                    throw new Exception("Invalid ID");
                id = value;
            }
        }
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (!MyFunctions.CheckName(value))
                    throw new Exception("Invalid name");
                firstName = value;
            }
        }
        public string MotherId
        {
            get { return motherId; }
            set
            {
                if (!MyFunctions.CheckID(value))
                    throw new Exception("Invalid ID");
                motherId = value;
            }
        }
        public DateTime Birthday
        {
            get { return birthday; }
            set
            {
                if (!MyFunctions.CheckDatePast(value))
                    throw new Exception("Invalid date");
                birthday = value;
            }
        }
        public bool SpecialNeeds { get { return specialNeeds; } set { specialNeeds = value; } }
        public string InfoSpecialNeeds { get { return infoSpecialNeeds; } set { infoSpecialNeeds = value; } }
        #endregion

        #region functions:
        public Child(string ID, string FN, string MID, DateTime birth, bool SN, string ISN)
        {
            if (!MyFunctions.CheckID(ID))
                throw new Exception("Invalid ID");
            if (!MyFunctions.CheckName(FN))
                throw new Exception("Invalid name");
            if (!MyFunctions.CheckID(MID))
                throw new Exception("Invalid ID");
            if (!MyFunctions.CheckDatePast(birth))
                throw new Exception("Invalid date");
            id = ID;
            firstName = FN;
            motherId = MID;
            birthday = birth;
            specialNeeds = SN;
            infoSpecialNeeds = ISN;

        }
        
        public Child()
        {
            birthday = new DateTime(2017, 1, 1);
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
