using System.Collections.Generic;

namespace Bank.Services
{
    public class BankHeadQuarters
    {
        private string _bankName;
        private string _address;
        private List<Customer> _branches;

        public BankHeadQuarters(string bankName, string address)
        {
            this._bankName = bankName;
            this._address = address;
        }

        public string DisplayName()
        {
            return this._bankName;
        }

        public string DisplayAddress()
        {
            return this._address;
        }

        public void AddBranch()
        {
            
        }
    }
}