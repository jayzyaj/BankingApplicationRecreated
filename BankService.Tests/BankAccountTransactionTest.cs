using Bank.Services;
using NUnit.Framework;


namespace Bank.UnitTests.Services
{
    [TestFixture]
    public class BankAccountTransactionTest
    {
        private Customer _customer;

        [SetUp]
        public void Setup()
        {
            this._customer = new Customer("Chae", "Young");
            this._customer.SetContactNumber("+639399399027");
            this._customer.SetEmail("deverajaycee17@gmail.com");
            this.OpenAccount();
        }

        public void OpenAccount()
        {
            this._customer.OpenBankAccount("savings", "Paseo De Roxas", 500.00m);
        }

        [Test]
        public void Should_Match_RemainingBalancePlusDepositFee_UponDeposit()
        {
            this._customer.DepositToAccount("1234", 500.50m);
            Assert.AreEqual("1000.50", this._customer.GetBankAccountRemainingBalance("1234"));
        }
    }
}