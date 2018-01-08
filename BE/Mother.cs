using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Mother
    {
        #region fields:
        private readonly string id;
        private string lastName;
        private string firstName;
        private string phoneNumber;
        private string address;
        private string areaNanny;//where the mother search Babysitter
        private bool[] needNanny;
        private float[,] workHours;
        private string notes;//Remarks or Requirements
        #endregion
        #region properties:
        public string Id { get { return id; } }
        public string LastName { get { return lastName; } set { lastName = value; } }
        public string FirstName { get { return firstName; } set { firstName = value; } }
        public string PhoneNumber { get { return phoneNumber; } set { phoneNumber = value; } }
        public string Address { get { return address; } set { address = value; } }
        public string AreaNanny { get { return areaNanny; } set { areaNanny = value; } }
        public bool[] NeedNanny { get { return needNanny; } set { needNanny = value; } }
        public string Notes { get { return notes; } set { notes = value; } }
        public float[,] WorkHours { get { return workHours; } set { workHours = value; } }
        #endregion
        #region functions:
        public Mother(string ID, string LN, string FN, string PN, string addr, string area, bool[] need,
            float[,] hours, string nt)
        {
            if (!MyFunctions.CheckID(ID) || !MyFunctions.CheckName(LN) || !MyFunctions.CheckName(FN) ||
                !MyFunctions.CheckPhoneNumber(PN) || !MyFunctions.CheckAddress(addr) || !MyFunctions.CheckAddress(area)
                || !MyFunctions.CheckArraySize(hours, need))
                throw new Exception();
            id = ID.Trim();//DELETE spare space
            lastName = LN.Trim();//DELETE spare space
            firstName = FN.Trim();//DELETE spare space
            phoneNumber = PN.Trim();
            address = addr;
            areaNanny = area;
            needNanny = need;
            workHours = new float[6, 2];
            workHours = hours;
            notes = nt;
        }
        public override string ToString()
        {
            string WH = "The required hours each day:", NEED = "Days when needs a nanny: ";
            for (int i = 0; i < 6; ++i)
            {
                NEED += ((DaysOfWeek)i).ToString();
                if (needNanny[i])
                    NEED += ": Yes ";
                else
                    NEED += ": No ";
                WH += ("\n" + ((DaysOfWeek)i).ToString() + "- Beginning time: " + (workHours[i, 0] / 100) + ":"
                    + (workHours[i, 0] % 100) + "End time: " + (workHours[i, 1] / 100) + ":" + (workHours[i, 1] % 100));
            }
            return "Id: " + Id + "\nFirst name: " + FirstName + "\nLast name: " + LastName + "\nPhone number: " +
                PhoneNumber + "\nAddress: " + Address + "\nAddress of area where she search a nanny: " + areaNanny
                + "\n" + NEED + "\n" + WH + "\nNotes: " + notes;
        }
        #endregion 
    }
}

