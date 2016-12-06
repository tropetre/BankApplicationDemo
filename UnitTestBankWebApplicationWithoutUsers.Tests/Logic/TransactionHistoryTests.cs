using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestBankWebApplicationWithoutUsers.Models;
using System.Linq;

namespace UnitTestBankWebApplicationWithoutUsers.Tests.TransactionHistory
{
    [TestClass]
    public class TransactionHistoryTests
    {
        [TestMethod]
        public void NewAccountHasNoHistory()
        {
            // Arrange
            var account = new Account { Balance = new MoneyAmount(12500) };

            // Act

            // Assert
            int expected = 0;
            Assert.AreEqual(expected, account.Transactions.Count);
        }

        [TestMethod]
        public void CompletingDepositAddsToHistory()
        {
            // Arrange
            var account = new Account { Balance = new MoneyAmount(12500) };

            // Act
            account.Deposit(new MoneyAmount(1000));

            // Assert
            int expected = 1;
            Assert.AreEqual(expected, account.Transactions.Count);
        }

        [TestMethod]
        public void CompletingWithdrawalAddsToHistory()
        {
            // Arrange
            var account = new Account
            {
                Balance = new MoneyAmount(12500)
            };

            // Act
            account.Withdraw(new MoneyAmount(1000));

            // Assert
            int expected = 1;
            Assert.AreEqual(expected, account.Transactions.Count);
        }

        [TestMethod]
        public void TransactionHistoryIsAddedToBothPartiesAfterTransaction()
        {
            // Arrange
            Account payee = new Account { Balance = new MoneyAmount(12500) };
            Account payor = new Account { Balance = new MoneyAmount(12500) };

            // Act
            payor.TransferTo(payee, new MoneyAmount(1000m));

            // Assert
            int expected = 1;
            Assert.AreEqual(expected, payor.Transactions.Count);
            Assert.AreEqual(expected, payee.Transactions.Count);
        }

        [TestMethod]
        public void TransactionHistoryIsCorrectInBothPartiesAfterTransaction()
        {
            // Arrange
            Account payee = new Account { Balance = new MoneyAmount(12500) };
            Account payor = new Account { Balance = new MoneyAmount(12500) };

            // Act
            payor.TransferTo(payee, new MoneyAmount(1000m));

            // Assert
            var expected = TransactionType.Deacquisition;
            Assert.AreEqual(expected, payor.Transactions.ElementAt(0).Type);

            expected = TransactionType.Acquisition;
            Assert.AreEqual(expected, payee.Transactions.ElementAt(0).Type);
        }
    }

}
