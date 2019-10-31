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
        private Account _bankAccount = null;

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

        public bool HasBankAccount()
        {
            if (this._bankAccount == null)
                return false;
            return true;
        }

        public void OpenBankAccount()
        {
            if (HasBankAccount())
                throw new Exception("You already have an existing bank account.");
            CheckingAccount newBankAccount = new CheckingAccount();
            this._bankAccount = newBankAccount;
            Console.WriteLine(this._bankAccount.DisplayBalance());
        }
    }
}