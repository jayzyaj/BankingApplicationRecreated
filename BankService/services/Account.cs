using System;

namespace Bank.Services
{
    public abstract class Account
    {
        protected string _accountName;
        protected int _accountNumber;
        protected string _branchName;
        protected int _pin;
        protected decimal _balance = 0;
        protected DateTime _openDate;
        protected DateTime _closeDate;

        public Account(string accountName, string branchName, decimal initialDeposit)
        {
            this._accountName = accountName;
            this._branchName = branchName;
            this._balance = initialDeposit;
            this._openDate = DateTime.Now;
        }

        public void Deposit()
        {

        }

        public void Withdraw()
        {

        }

        public decimal DisplayBalance()
        {
            return this._balance;
        }

        public string GetAccountName()
        {
            return this._accountName;
        }

        public string GetBranchName()
        {
            return this._branchName;
        }

        public string GetDateUponOpeningAccount()
        {
            return this._openDate.ToString("M/d/yyyy");
        }
    }
}