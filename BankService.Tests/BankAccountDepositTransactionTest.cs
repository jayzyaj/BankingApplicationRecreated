using Bank.Services;
using NUnit.Framework;


namespace Bank.UnitTests.Services
{
    [TestFixture]
    public class BankAccountDepositTransactionTest
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

        [Test]
        public void Should_NotAllowCustomer_ToDepositNegativeAmount()
        {
            Assert.That(() => this._customer.DepositToAccount("1234", -500.23m), Throws.Exception);
        }

        [Test]
        public void Should_NotAllowCustomer_ToDepositLessThanMinimumAmount()
        {
            Assert.That(() => this._customer.DepositToAccount("1234", 99.99m), Throws.Exception);
        }

        [Test]
        public void Should_AllowCustomer_ToDepositExactMinimumAmount()
        {
            this._customer.DepositToAccount("1234", 100.00m);
            Assert.AreEqual("600.00", this._customer.GetBankAccountRemainingBalance("1234"));
        }

        [Test]
        public void Should_AddPrecision_ToCurrency_WhenPrecisionGoesAbove()
        {
            this._customer.DepositToAccount("1234", 100.99m);
            this._customer.DepositToAccount("1234", 100.02m);
            Assert.AreEqual("701.01", this._customer.GetBankAccountRemainingBalance("1234"));
        }

        [Test]
        public void Should_Match_ThousandsWhenPrecisionAddedUp()
        {
            this._customer.DepositToAccount("1234", 399.99m);
            this._customer.DepositToAccount("1234", 100.01m);
            Assert.AreEqual("1000.00", this._customer.GetBankAccountRemainingBalance("1234"));
        }
    }
}