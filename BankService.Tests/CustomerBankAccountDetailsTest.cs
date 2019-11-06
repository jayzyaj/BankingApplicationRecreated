using NUnit.Framework;
using Bank.Services;

namespace Bank.UnitTests.Services
{
    [TestFixture]
    public class CustomerBankAccountDetailsTest
    {
        private Customer _customer;

        [SetUp]
        public void Setup()
        {
            this._customer = new Customer("Chae", "Young");
            this._customer.SetContactNumber("+639399399027");
            this._customer.SetEmail("deverajaycee17@gmail.com");
        }

        public void OpenAccount()
        {
            this._customer.OpenBankAccount(AccountType.Checking, "Paseo De Roxas", 500.00m);
        }

        [Test]
        public void Should_Allow_User_ToOpen_BankAccount()
        {
            this.OpenAccount();
            Assert.IsTrue(this._customer.HasBankAccount());
            Assert.IsNotNull(this._customer.GetBankAccountDetails("1234"));
        }

        [Test]
        public void Should_Not_Allow_User_ToOpen_BankAccount_IfHasOne()
        {
            this.OpenAccount();
            Assert.That(() => this._customer.OpenBankAccount(AccountType.Checking, "Ayala Avenue", 500.00m), Throws.Exception);
        }

        [Test]
        public void Should_Not_Allow_User_To_Access_AnyDetails_IfPinIsInvalid()
        {
            this.OpenAccount();
            Assert.That(() => this._customer.GetBankAccountDetails("1345"), Throws.Exception);
        }

        [Test]
        public void Should_Match_AccountName_ToBe_UserFullName()
        {
            this.OpenAccount();
            Assert.AreEqual("CHAE YOUNG", this._customer.GetBankAccountName("1234"));
        }

        // [Test]
        // public void Should_Match_DateTimeUponOpening_ToBe_DateTimeTheUserOpenAnAccount()
        // {
        //     this.OpenAccount();
        //     Assert.AreEqual("11/6/2019", this._customer.GetBankAccountDateUponOpening("1234"));
        // }

        [Test]
        public void Should_Match_BranchName_ToBe_BranchWhereUserOpenAccount()
        {
            this._customer.OpenBankAccount(AccountType.Savings, "Jupiter Avenue", 500.00m);
            Assert.AreEqual("Jupiter Avenue", this._customer.GetBankAccountBranch("1234"));
        }

        [Test]
        public void Should_Validate_IfOldPinIsIncorrect_WhenChangingPin()
        {
            this.OpenAccount();
            Assert.That(() => this._customer.ChangeBankAccountPin("4321", "2332"), Throws.Exception);
        }

        [Test]
        public void Should_Validate_IfPinIsChanged()
        {
            this._customer.OpenBankAccount(AccountType.Savings, "Jupiter Avenue", 500.00m);
            this._customer.ChangeBankAccountPin("1234", "2332");
            Assert.AreEqual("Jupiter Avenue", this._customer.GetBankAccountBranch("2332"));
        }

        [Test]
        public void Should_Match_InitialDeposit_With_RemainingBalance()
        {
            this._customer.OpenBankAccount(AccountType.Savings, "Jupiter Avenue", 500.00m);
            Assert.AreEqual("500.00", this._customer.GetBankAccountRemainingBalance("1234"));
        }

        [Test]
        public void Should_Not_AllowCustomer_ToClose_Account_IfThereIsRemainingBalance()
        {
            this.OpenAccount();
            Assert.That(() => this._customer.CloseBankAccount("1234"), Throws.Exception);
        }

        [Test]
        public void Should_Not_AllowCustomer_ToClose_Account_IfPinIsIncorrect()
        {
            this.OpenAccount();
            Assert.That(() => this._customer.CloseBankAccount("4321"), Throws.Exception);
        }

        // [Test]
        // public void ShouldAllowCustomer_ToClose_Account_IfThereIsNoRemainingBalance()
        // {
        //     this.OpenAccount();
        //     this._customer.WithdrawToAccount("1234", 500.00m);
        //     this._customer.CloseBankAccount("1234");
        //     Assert.AreEqual("11/6/2019", this._customer.GetBankAccountClosedDate());
        //     // Assert.That(() => this._customer.CloseBankAccount(), Is.);
        // }
    }
}