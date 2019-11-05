using System;

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

        public void Deposit()
        {

        }

        public void Withdraw()
        {

        }

        public decimal DisplayBalance(string pin)
        {
            if (!this.VerifyPin(pin))
                throw new Exception("Old Pin is incorrect");

            return this._balance;
        }

        public string GetAccountName(string pin)
        {
            if (!this.VerifyPin(pin))
                throw new Exception("Old Pin is incorrect");

            return this._accountName;
        }

        public string GetBranchName(string pin)
        {
            if (!this.VerifyPin(pin))
                throw new Exception("Old Pin is incorrect");

            return this._branchName;
        }

        public string GetDateUponOpeningAccount(string pin)
        {
            if (!this.VerifyPin(pin))
                throw new Exception("Old Pin is incorrect");

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