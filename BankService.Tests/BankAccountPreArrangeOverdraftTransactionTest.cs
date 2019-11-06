using Bank.Services;
using NUnit.Framework;


namespace Bank.UnitTests.Services
{
    [TestFixture]
    public class BankAccountPreArrangeOverdraftTransactionTest
    {
        private Customer _customer;

        [SetUp]
        public void Setup()
        {
            this._customer = new Customer("Chae", "Young");
            this._customer.SetContactNumber("+639399399027");
            this._customer.SetEmail("deverajaycee17@gmail.com");
            this._customer.OpenBankAccount(AccountType.Savings, "Paseo De Roxas", 500.00m);
        }

        [Test]
        public void Should_NotAllowUser_To_AuthorizedOrSign_PreArrangeOverdraft_IfRequestedOverdraftFee_IsMore_ThanZero()
        {
            Assert.That(() => this._customer.ApplyAccountAgreedOverdraft("1234", 1000.00m), Throws.Exception);
        }

        [Test]
        public void Should_NotAllowUser_To_AuthorizedOrSign_PreArrangeOverdraft_IfRequestedOverdraftFee_IsMore_TenThousandCredit()
        {
            Assert.That(() => this._customer.ApplyAccountAgreedOverdraft("1234", -10000.01m), Throws.Exception);
        }

        [Test]
        public void Should_NotAllowUser_To_AuthorizedOrSign_PreArrangeOverdraft_IfRequestedOverdraftFee_IsNotDivisibleByHundreds()
        {
            Assert.That(() => this._customer.ApplyAccountAgreedOverdraft("1234", -5050.00m), Throws.Exception);
        }

        [Test]
        public void Should_AllowUser_To_AuthorizedOrSign_PreArrangeOverdraft_IfRequestedOverdraftFee_IsValid()
        {
            this._customer.ApplyAccountAgreedOverdraft("1234", -5000.00m);
            Assert.AreEqual(this._customer.GetAccountOverdraftLimit("1234"), "-5000.00");
        }

        [Test]
        public void Should_Not_AllowUser_To_Withdraw_MoreThanOverdraftFeeLimit()
        {
            this._customer.ApplyAccountAgreedOverdraft("1234", -5000.00m);
            Assert.That(() => this._customer.WithdrawToAccount("1234", 5501.00m), Throws.Exception);
        }

        [Test]
        public void Should_AllowUser_To_Withdraw_LessThanOverdraftFeeLimit()
        {
            this._customer.ApplyAccountAgreedOverdraft("1234", -5000.00m);
            this._customer.WithdrawToAccount("1234", 3000.00m);
            Assert.AreEqual("-2500.00", this._customer.GetBankAccountRemainingBalance("1234"));
        }
    }
}