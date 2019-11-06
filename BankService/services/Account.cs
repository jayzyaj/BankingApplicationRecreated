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
        protected decimal _preArrangeOverdraftFee = 100.00m;
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

            if (amount < 0)
                throw new Exception("Amount should be not be 0");

            if (amount > this._balance && (this._balance - amount) < this._preArrangeOverdraftFee)
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

        public void ApplyPreArrangeOverdraft(string pin, decimal preArrangeAmount)
        {
            if (!this.VerifyPin(pin))
                throw new Exception("PIN is incorrect");

            if (preArrangeAmount > 0)
                throw new Exception("Overdraft amount fee limit should not be greater than 0");
            
            if (preArrangeAmount < -10000.00m)
                throw new Exception("This bank only allows maximum overdraft fee of 10,000.00");
            
            if (!IsDivisibleByHundreds(preArrangeAmount))
                throw new Exception("Amount should only be divisible by hundreds");

            this._preArrangeOverdraftFee = preArrangeAmount;
        }

        public string GetOverdraftLimit(string pin)
        {
            if (!this.VerifyPin(pin))
                throw new Exception("PIN is incorrect");

            return this._preArrangeOverdraftFee.ToString();
        }

        public void CloseAccount(string pin)
        {
            if (!this.VerifyPin(pin))
                throw new Exception("PIN is incorrect");

            if (this._balance != 0.00m)
                throw new Exception("Please withdraw all your remaining balance before closing account");
            
            this._closeDate = DateTime.Now;
        }

        public string GetClosedDate()
        {
            if (this._closeDate == null)
                throw new Exception("The account is still active");

            return this._closeDate.ToString("M/d/yyyy");
        }
    }
}