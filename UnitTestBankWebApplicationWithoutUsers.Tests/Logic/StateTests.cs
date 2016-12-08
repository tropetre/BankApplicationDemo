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
            var account = new Account { Balance = new decimal(12500) };

            // Act
            account.Deposit(new decimal(1000));

            // Assert
            decimal expected = new decimal(13500);
            Assert.AreEqual(expected, account.Balance);
        }

        [TestMethod]
        public void MoneyCanBeWithdrawnFromActiveAccount()
        {
            // Arrange
            var account = new Account { Balance = new decimal(12500) };

            // Act
            account.Withdraw(new decimal(1000));

            // Assert
            decimal expected = new decimal(11500);
            Assert.AreEqual(expected, account.Balance);
        }

        [TestMethod]
        public void MoneyCanBeDepositToFrozenAccount()
        {
            // Arrange
            var account = new Account { Balance = new decimal(12500), State = AccountStateType.Frozen };

            // Act
            account.Deposit(new decimal(1000));

            // Assert
            decimal expected = new decimal(13500);
            Assert.AreEqual(expected, account.Balance);
        }

        [TestMethod]
        public void MoneyCantBeWithdrawnFromFrozenAccount()
        {
            // Arrange
            var account = new Account { Balance = new decimal(12500), State = AccountStateType.Frozen };

            // Act
            account.Withdraw(new decimal(1000));

            // Assert
            decimal expected = new decimal(12500);
            Assert.AreEqual(expected, account.Balance);
        }

        [TestMethod]
        public void AccountCanBeFrozen()
        {
            // Arrange
            var account = new Account { Balance = new decimal(12500) };

            // Act
            account.Freeze();

            // Assert
            Assert.AreEqual(AccountStateType.Frozen, account.State);
        }

        [TestMethod]
        public void AccountCanBeInitializedAsFrozen()
        {
            // Arrange
            var account = new Account { Balance = new decimal(12500), State = AccountStateType.Frozen };

            // Act

            // Assert
            Assert.AreEqual(AccountStateType.Frozen, account.State);
        }

        [TestMethod]
        public void AccountRemainsFrozen()
        {
            // Arrange
            var account = new Account { Balance = new decimal(12500), State = AccountStateType.Frozen };

            // Act
            account.Freeze();

            // Assert
            Assert.AreEqual(AccountStateType.Frozen, account.State);
        }

        [TestMethod]
        public void AccountCanBeFrozenAndMoneyCantBeWithdrawn()
        {
            // Arrange
            var account = new Account { Balance = new decimal(12500) };

            // Act
            account.Freeze();
            account.Withdraw(new decimal(1000));

            // Assert
            decimal expected = new decimal(12500);
            Assert.AreEqual(expected, account.Balance);
        }

        [TestMethod]
        public void AccountCanBeFrozenAndMoneyCanBeDeposit()
        {
            // Arrange
            var account = new Account { Balance = new decimal(12500) };

            // Act
            account.Freeze();
            account.Deposit(new decimal(1000));

            // Assert
            decimal expected = new decimal(13500);
            Assert.AreEqual(expected, account.Balance);
        }
    }
}
