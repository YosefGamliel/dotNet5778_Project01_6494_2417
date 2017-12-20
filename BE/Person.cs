using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    class Person
    {
        //fields:
        #region
        private int id;
        private string lastName;
        private string firstName;
        private int phoneNumber;
        private string address;
        #endregion
        //properies:
        #region
        public int Id { get { return id; } set { id = value; } }
        public string LastName { get { return lastName; } set { lastName = value; } }
        public string FirstName { get { return firstName; } set { firstName = value; } }
        public int PhoneNumber { get { return phoneNumber; } set { phoneNumber = value; } }
        public string Address { get { return address; } set { address = value; } }
        #endregion
        //functions:
        #region
        public Person(int ID, string LN, string FN, int PN, string addr)
        {
            id = ID;
            lastName = LN;
            firstName = FN;
            phoneNumber = PN;
            address = addr;
        }
        public override string ToString()
        {
            return "Id: " + id + "\nFirst name: " + firstName + "\nLast name: " + lastName + "\nPhone number: "
                + phoneNumber + "\nAddress: " + address + "\n";
        }
        #endregion
    }

}
