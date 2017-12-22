using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    class Contract
    {
        //fields:
        #region
        private string contractID;
        private readonly string babySitterID;
        private readonly string childID;
        private readonly bool firsMeating;
        private bool signed;
        private float salaryPerHour;
        private float salaryPerMonth;
        private string type;
        private DateTime start;
        private DateTime end;
        #endregion
        //properties:
        #region
        public string ContractID { get { return contractID; } set { contractID = value; } }
        public string BabySitterID { get { return babySitterID; } }
        public string ChildID { get { return childID; } }
        public bool FirsMeating { get { return firsMeating; } }
        public bool Signed { get { return signed; } set { signed = value; } }
        public float SalaryPerHour { get { return salaryPerHour; } set { salaryPerHour = value; } }
        public float SalaryPerMonth { get { return salaryPerMonth; } set { salaryPerMonth = value; } }
        public string Type { get { return type; } set { type = value; } }
        public DateTime Start { get { return start; } set { start = value; } }
        public DateTime End { get { return end; } set { end = value; } }
        #endregion
        //finction:
        #region
        public Contract(string ConID, string BID, string ChID, bool FM, bool S, float SPH, float SPM, string T, DateTime St, DateTime E)
        {
            try
            {
                if(!MyFunctions.CheckCoIDandDate(contractID,E,St)|| !MyFunctions.CheckID(BID)|| !MyFunctions.CheckID(ChID))
                    throw new Exception();
                contractID = ConID;
                babySitterID = BID;
                childID = ChID;
                firsMeating = FM;
                signed = S;
                salaryPerHour = SPH;
                salaryPerMonth = SPM;
                type = T;
                start = St;
                end = E;
            }
        }
        public override string ToString()
        {
            string str1, str2;
            if (firsMeating) str1 = "Yes";
            else str1 = "No";
            if (signed) str2 = "Yes";
            else str2 = "No";
            return "Contract number: " + contractID + "\nBaybysitter ID: " + babySitterID + "\nChild id: " + childID +
                "\nWas there a first meeting?: " + str1 + "\nThe contract was signed?: " + str2 + "\nContract type: " + type
                + "\nSalary per hour: " + salaryPerHour +"\nSalary per month: " + salaryPerMonth + "\nStarted to work in: " + start
                + "\nFinshed to work in: " + end;
        }
        #endregion

    }
}
