﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Contract
    {
        #region fields:
        private string contractID;
        private readonly string babySitterID;
        private readonly string childID;
        private  string motherID;
        private readonly bool firsMeating;
        private bool signed;
        private float salaryPerHour;
        private float salaryPerMonth;
        private bool salaryType;//true - per hour, false - per month
        private DateTime start;
        private DateTime end;
        private double payment;
        private float discount;
        private string v1;
        private string v2;
        private bool v3;
        private DateTime birth;
        private DateTime end1;
        #endregion
        #region properties:
        public string ContractID { get { return contractID; } set { contractID = value; } }
        public string BabySitterID { get { return babySitterID; } }
        public string ChildID { get { return childID; } }
        public string MotherID { get { return motherID; } set { motherID = value; } }
        public bool FirsMeating { get { return firsMeating; } }
        public bool Signed { get { return signed; } set { signed = value; } }
        public float SalaryPerHour { get { return salaryPerHour; } set { salaryPerHour = value; } }
        public float SalaryPerMonth { get { return salaryPerMonth; } set { salaryPerMonth = value; } }
        public bool SalaryType { get { return salaryType; } set { salaryType = value; } }
        public DateTime Start { get { return start; } set { start = value; } }
        public DateTime End { get { return end; } set { end = value; } }
        public double Payment { get { return payment; } set { payment = value; } }
        public float Discount { get { return discount; } set { discount = value; } }
        #endregion
        #region finction:
        public Contract(string BID, string ChID, bool FM, 
            bool T, DateTime St, DateTime E)
        {
            if (!MyFunctions.CheckContract(E, St) || !MyFunctions.CheckID(BID) ||
                !MyFunctions.CheckID(ChID) )
                throw new Exception();
            babySitterID = BID;
            childID = ChID;
            // motherID = MID; update Automatically in DAL layer
            firsMeating = FM;
            start = St;
            end = E;
            payment = 0;
            discount = 0;

        }

        public Contract(string v1, string v2, bool v3, DateTime birth, DateTime end1)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.birth = birth;
            this.end1 = end1;
        }

        public override string ToString()
        {
            string str1, str2;
            if (firsMeating) str1 = "Yes";
            else str1 = "No";
            if (signed) str2 = "Yes";
            else str2 = "No";
            return "Contract number: " + contractID + "\nBaybysitter ID: " + babySitterID + "\nChild id: " +
                childID + "\nWas there a first meeting?: " + str1 + "\nThe contract was signed?: " + str2 +
                "\nContract type: " + salaryType + "\nSalary per hour: " + salaryPerHour + "\nSalary per month: " +
                salaryPerMonth + "\nStarted to work in: " + start + "\nFinshed to work in: " + end + "\nPayment: " +
                payment + "\nDiscount for the nanny: " + discount;
        }
        #endregion

    }
}
