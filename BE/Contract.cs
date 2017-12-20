using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    class Contract
    {
        //fields:
        #region
        int contractID;
        int babySitterID;
        int childID;
        bool firsMeating;//האם נעשתה פגישת היכרות
        bool signed;
        float salaryPerHour;
        float salaryPerMonth;
        string type;//חודשי או שעתי
        DateTime start;
        DateTime end;
        #endregion
        //properties:
        #region
        public int ContractID { get { return contractID; } set { contractID = value; } }
        public int BabySitterID { get { return babySitterID; } set { babySitterID = value; } }
        public int ChildID { get { return childID; } set { childID = value; } }
        public bool FirsMeating { get { return firsMeating; } set { firsMeating = value; } }
        public bool Signed { get { return signed; } set { signed = value; } }
        public float SalaryPerHour { get { return salaryPerHour; } set { salaryPerHour = value; } }
        public float SalaryPerMonth { get { return salaryPerMonth; } set { salaryPerMonth = value; } }
        public string Type { get { return type; } set { type = value; } }
        public DateTime Start { get { return start; } set { start = value; } }
        public DateTime End { get { return end; } set { end = value; } }
        #endregion
        //finction:
        #region
        public Contract(int ConID,int BID,int ChID ,bool FM,bool S, float SPH, float SPM,string T,DateTime St,DateTime E)
        {
            contractID = ConID;
            babySitterID = BID;
            childID = ChID;
            firsMeating = FM;//האם נעשתה פגישת היכרות
            signed = S;
            salaryPerHour = SPH;
            salaryPerMonth = SPM;
            type = T;//חודשי או שעתי
            start = St;
            end = E;
        }
        public override string ToString()
        {
            string str1,str2;
            if (firsMeating) str1 = "Yes";
            else str1 = "No";
            if (signed) str2 = "Yes";
            else str2 = "No";



            return "contract number: " + contractID + "\nBaybysitter ID: " + babySitterID + "\nChild id: " + childID +
                "\nWas there a first meeting?: " + str1 + "\nThe contract was signed ? : " + str2 + "contract type:" + type + "\nsalary per hour;" + salaryPerHour +
                "    salary per month:" + salaryPerMonth + "start working in :" + start + "\nfinsh working in :" + end;

        }
        #endregion


    }
}
