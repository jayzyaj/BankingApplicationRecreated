using System;

namespace Bank.Services
{
    public abstract class Account
    {
        protected string _bank;
        protected string _accountName;
        protected int _accountNumber;
        protected int _pin;
        protected int _balance = 0;

        public void Deposit()
        {

        }

        public void Withdraw()
        {

        }

        public int DisplayBalance()
        {
            return this._balance;
        }
    }
}