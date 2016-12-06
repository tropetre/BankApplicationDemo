using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestBankWebApplicationWithoutUsers.Models;
using UnitTestBankWebApplicationWithoutUsers.Models.AccountStates;

namespace UnitTestBankWebApplicationWithoutUsers.Tests.States
{
    [TestClass]
    public class StateTests
    {
        [TestMethod]
        public void MoneyCanBeDepositToActiveAccount()
        {
            // Arrange
            var account = new Account { Balance = new MoneyAmount(12500) };

            // Act
            account.Deposit(new MoneyAmount(1000));

            // Assert
            MoneyAmount expected = new MoneyAmount(13500);
            Assert.AreEqual(expected, account.Balance);
        }

        [TestMethod]
        public void MoneyCanBeWithdrawnFromActiveAccount()
        {
            // Arrange
            var account = new Account { Balance = new MoneyAmount(12500) };

            // Act
            account.Withdraw(new MoneyAmount(1000));

            // Assert
            MoneyAmount expected = new MoneyAmount(11500);
            Assert.AreEqual(expected, account.Balance);
        }

        [TestMethod]
        public void MoneyCanBeDepositToFrozenAccount()
        {
            // Arrange
            var account = new Account { Balance = new MoneyAmount(12500), State = new Frozen() };

            // Act
            account.Deposit(new MoneyAmount(1000));

            // Assert
            MoneyAmount expected = new MoneyAmount(13500);
            Assert.AreEqual(expected, account.Balance);
        }

        [TestMethod]
        public void MoneyCantBeWithdrawnFromFrozenAccount()
        {
            // Arrange
            var account = new Account { Balance = new MoneyAmount(12500), State = new Frozen() };

            // Act
            account.Withdraw(new MoneyAmount(1000));

            // Assert
            MoneyAmount expected = new MoneyAmount(12500);
            Assert.AreEqual(expected, account.Balance);
        }

        [TestMethod]
        public void AccountCanBeFrozenAndMoneyCantBeWithdrawn()
        {
            // Arrange
            var account = new Account { Balance = new MoneyAmount(12500) };

            // Act
            account.Freeze();
            account.Withdraw(new MoneyAmount(1000));

            // Assert
            MoneyAmount expected = new MoneyAmount(12500);
            Assert.AreEqual(expected, account.Balance);
        }

        [TestMethod]
        public void AccountCanBeFrozenAndMoneyCanBeDeposit()
        {
            // Arrange
            var account = new Account { Balance = new MoneyAmount(12500) };

            // Act
            account.Freeze();
            account.Deposit(new MoneyAmount(1000));

            // Assert
            MoneyAmount expected = new MoneyAmount(13500);
            Assert.AreEqual(expected, account.Balance);
        }
    }
}
