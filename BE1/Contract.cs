﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BE1
{
    public class Contract
    {
        #region fields:
        private string contractID;
        private string babySitterID;
        private string childID;
        private string motherID;
        private bool firsMeating;
        private bool signed;
        private float salaryPerHour;
        private float salaryPerMonth;
        private bool salaryType;//true - per hour, false - per month
        private DateTime start;
        private DateTime end;
        private double payment;
        private float discount;
        #endregion

        #region properties:
        public string ContractID { get { return contractID; } set { contractID = value; } }
        public string BabySitterID
        {
            get { return babySitterID; }
            set
            {
                if (!MyFunctions.CheckID(value))
                    throw new Exception("Invalid ID");
                babySitterID = value;
            }
        }
        public string ChildID
        {
            get { return childID; }
            set
            {
                if (!MyFunctions.CheckID(value))
                    throw new Exception("Invalid ID");
                childID = value;
            }
        }
        public string MotherID { get { return motherID; } set { motherID = value; } }
        public bool FirsMeating { get { return firsMeating; } set { firsMeating = value; } }
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
        public Contract(string BID, string ChID, bool FM, bool T, DateTime St, DateTime E)
        {
            if (!MyFunctions.CheckContract(E, St))
                throw new Exception("Invalid hours");
            if (!MyFunctions.CheckID(BID))
                throw new Exception("Invalid ID");
            if (!MyFunctions.CheckID(ChID))
                throw new Exception("Invalid ID");
            babySitterID = BID;
            childID = ChID;
            firsMeating = FM;
            start = St;
            end = E;
            salaryType = T;
            payment = 0;
            discount = 0;

        }

        public Contract()
        {
        }
        public override string ToString()
        { return ContractID; }
        //public override string ToString()
        //{
        //    string str1, str2;
        //    if (firsMeating) str1 = "Yes";
        //    else str1 = "No";
        //    if (signed) str2 = "Yes";
        //    else str2 = "No";
        //    return "Contract number: " + contractID + "\nBaybysitter ID: " + babySitterID + "\nChild id: " +
        //        childID + "\nWas there a first meeting?: " + str1 + "\nThe contract was signed?: " + str2 +
        //        "\nContract type: " + salaryType + "\nSalary per hour: " + salaryPerHour + "\nSalary per month: " +
        //        salaryPerMonth + "\nStarted to work in: " + start + "\nFinshed to work in: " + end + "\nPayment: " +
        //        payment + "\nDiscount for the nanny: " + discount;
        //}
        #endregion

    }
}
