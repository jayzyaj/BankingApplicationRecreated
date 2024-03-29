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

        public void OpenBankAccount(AccountType accountType, string branchName, decimal initialDeposit)
        {
            if (this.HasBankAccount())
                throw new Exception("You already have an existing bank account.");

            Account newBankAccount = this.InitBankAccount(
                accountType,
                branchName,
                initialDeposit
            );

            this._bankAccount = newBankAccount;
        }

        public Account InitBankAccount(AccountType accountType, string branchName, decimal initialDeposit)
        {
            Account newBankAccount = null;
            if (accountType == AccountType.Checking)
                return newBankAccount = new CheckingAccount(
                    this.GetFullName().ToUpper(),
                    branchName,
                    initialDeposit
                );
            else if (accountType == AccountType.Savings)
                return newBankAccount = new SavingsAccount(
                    this.GetFullName().ToUpper(),
                    branchName,
                    initialDeposit
                );
            else
                throw new Exception("Something went wrong on choosing your account type.");
        }

        public Account GetBankAccountDetails(string pin)
        {
            if (!this.HasBankAccount())
                throw new Exception("You don't have an existing bank account.");
            
            if (!this._bankAccount.VerifyPin(pin))
                throw new Exception("Invalid PIN enterred.");
            
            return this._bankAccount;
        }

        public string GetBankAccountRemainingBalance(string pin)
        {
            return this._bankAccount.DisplayBalance(pin);
        }

        public void DepositToAccount(string pin, decimal amount)
        {
            this._bankAccount.Deposit(pin, amount);
        }

        public string WithdrawToAccount(string pin, decimal amount)
        {
            return this._bankAccount.Withdraw(pin, amount);
        }

        public void ApplyAccountAgreedOverdraft(string pin, decimal preArrangeAmount)
        {
            this._bankAccount.ApplyPreArrangeOverdraft(pin, preArrangeAmount);
        }

        public string GetAccountOverdraftLimit(string pin)
        {
            return this._bankAccount.GetOverdraftLimit(pin);
        }

        public string GetBankAccountName(string pin)
        {
            return this._bankAccount.GetAccountName(pin);
        }

        public string GetBankAccountBranch(string pin)
        {
            return this._bankAccount.GetBranchName(pin);
        }

        public string GetBankAccountDateUponOpening(string pin)
        {
            return this._bankAccount.GetDateUponOpeningAccount(pin);
        }

        public void ChangeBankAccountPin(string oldPin, string newPin)
        {
            this._bankAccount.ChangePin(oldPin, newPin);
        }

        public void CloseBankAccount(string pin)
        {
            this._bankAccount.CloseAccount(pin);
        }

        public string GetBankAccountClosedDate()
        {
            return this._bankAccount.GetClosedDate();
        }
    }
}