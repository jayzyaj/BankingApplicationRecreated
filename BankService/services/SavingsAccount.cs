using System;

namespace Bank.Services
{
    public class SavingsAccount : Account
    {
        public SavingsAccount(string accountName, string branchName, decimal initialDeposit)
        : base(accountName, branchName, initialDeposit)
        {
            this._accountName = accountName;
            this._branchName = branchName;
            this._balance = initialDeposit;
            // this._openDate = new DateTime();
        }
    }
}