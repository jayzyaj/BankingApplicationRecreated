using NUnit.Framework;
using Bank.Services;

namespace Bank.UnitTests.Services
{
    [TestFixture]
    public class BankAccountTest
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
            this._customer.OpenBankAccount("savings", "Paseo De Roxas", 500.00m);
        }

        [Test]
        public void Should_Allow_User_ToOpen_BankAccount()
        {
            this.OpenAccount();
            Assert.IsTrue(this._customer.HasBankAccount());
            Assert.IsNotNull(this._customer.GetBankAccountDetails());
        }

        [Test]
        public void Should_Not_Allow_User_ToOpen_BankAccount_IfHasOne()
        {
            this.OpenAccount();
            Assert.That(() => this._customer.OpenBankAccount("checking", "Ayala Avenue", 500.00m), Throws.Exception);
        }

        [Test]
        public void Should_Match_AccountName_ToBe_UserFullName()
        {
            this.OpenAccount();
            Assert.AreEqual("CHAE YOUNG", this._customer.GetBankAccountName());
        }

        [Test]
        public void Should_Match_DateTimeUponOpening_ToBe_DateTimeTheUserOpenAnAccount()
        {
            this.OpenAccount();
            Assert.AreEqual("11/5/2019", this._customer.GetBankAccountDateUponOpening());
        }

        [Test]
        public void Should_Match_BranchName_ToBe_BranchWhereUserOpenAccount()
        {
            this._customer.OpenBankAccount("savings", "Jupiter Avenue", 500.00m);
            Assert.AreEqual("Jupiter Avenue", this._customer.GetBankAccountBranch());
        }
    }
}