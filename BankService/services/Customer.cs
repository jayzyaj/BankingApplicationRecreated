using System;
using static Helpers.Helper;

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
            return $"{CapitalizeFirstLetter(this._firstName)} {CapitalizeFirstLetter(this._lastName)}";
        }

        public void SetEmail(string email)
        {
            if (ValidateEmail(email))
                this._email = email;
            else
                throw new Exception("Email is invalid");
        }

        public void SetContactNumber(string contactNumber)
        {
            if (ValidateContactNumber(contactNumber))
                this._contactNumber = contactNumber;
            else
                throw new Exception("Phone number is invalid");
        }

        public string GetEmail()
        {
            return this._email;
        }

        public string GetContactNumber()
        {
            return this._contactNumber;
        }
    }
}