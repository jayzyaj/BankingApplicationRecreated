using System;
using static Helpers.Helper;

namespace Bank.Services
{
    public abstract class Account
    {
        protected string _accountName;
        protected int _accountNumber;
        protected string _branchName;
        protected string _pin;
        protected decimal _balance = 0;
        protected DateTime _openDate;
        protected DateTime _closeDate;

        public Account(string accountName, string branchName, decimal initialDeposit)
        {
            this._accountName = accountName;
            this._branchName = branchName;
            this._balance = initialDeposit;
            this._pin = "1234";
            this._openDate = DateTime.Now;
        }

        public void Deposit(string pin, decimal amount)
        {
            if (!this.VerifyPin(pin))
                throw new Exception("PIN is incorrect");

            if (amount < 100.00m)
                throw new Exception("Amount should be 100.00 or more");

            this._balance += amount;
        }

        public string Withdraw(string pin, decimal amount)
        {
            if (!this.VerifyPin(pin))
                throw new Exception("PIN is incorrect");

            if (amount < 100.00m)
                throw new Exception("Amount should be 100.00 or more");

            if (amount > this._balance)
                throw new Exception("Amount should not be greater than your remaining balance");

            if (amount > this._balance)
                throw new Exception("Amount should not be greater than your remaining balance");

            if (!IsDivisibleByHundreds(amount))
                throw new Exception("Amount should only be divisible by hundreds");

            this._balance -= amount;

            return amount.ToString();
        }

        public string DisplayBalance(string pin)
        {
            if (!this.VerifyPin(pin))
                throw new Exception("PIN is incorrect");

            return this._balance.ToString();
        }

        public string GetAccountName(string pin)
        {
            if (!this.VerifyPin(pin))
                throw new Exception("PIN is incorrect");

            return this._accountName;
        }

        public string GetBranchName(string pin)
        {
            if (!this.VerifyPin(pin))
                throw new Exception("PIN is incorrect");

            return this._branchName;
        }

        public string GetDateUponOpeningAccount(string pin)
        {
            if (!this.VerifyPin(pin))
                throw new Exception("PIN is incorrect");

            return this._openDate.ToString("M/d/yyyy");
        }

        public bool VerifyPin(string pin)
        {
            if (this._pin != pin)
                return false;
            return true;
        }

        public void ChangePin(string oldPin, string newPin)
        {
            if (!this.VerifyPin(oldPin))
                throw new Exception("Old Pin is incorrect");
            else
                this._pin = newPin;
        }
    }
}