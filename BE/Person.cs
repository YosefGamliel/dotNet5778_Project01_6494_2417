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
        private DateTime birthday;
        #endregion
        //properies:
        #region
        public int Id { get { return id; } set { id = value; } }
        public string LastName { get { return lastName; } set { lastName = value; } }
        public string FirstName { get { return firstName; } set { firstName = value; } }
        public int PhoneNumber { get { return phoneNumber; } set { phoneNumber = value; } }
        public string Address { get { return address; } set { address = value; } }
        public DateTime Birthday { get { return birthday; } set { birthday = value; } }
        #endregion
    }

}
