// using System;
using Helpers;

namespace Bank.Services
{
    public class Customer
    {
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _contactNumber;
        private Bank bankAccount = null;

        public Customer(string fName, string lName)
        {
            this._firstName = fName;
            this._lastName = lName;
        }

        public string GetFullName()
        {
            return $"{Helper.CapitalizeFirstLetter(this._firstName)} {Helper.CapitalizeFirstLetter(this._lastName)}";
        }
    }
}