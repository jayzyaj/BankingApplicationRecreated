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

        [Test]
        public void Should_Allow_User_ToOpen_BankAccount()
        {
            // this._customer.OpenBankAccount("HSBC", this._customer.GetFullName, 10171996, 100.00);
            this._customer.OpenBankAccount("savings", "Paseo De Roxas", 500.00m);
            Assert.IsTrue(this._customer.HasBankAccount());
        }
    }
}