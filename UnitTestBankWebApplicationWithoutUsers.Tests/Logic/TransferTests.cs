using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestBankWebApplicationWithoutUsers.Models;
using System.Collections.Generic;

namespace UnitTestBankWebApplicationWithoutUsers.Tests.TransferTests
{
    [TestClass]
    public class TransferTests
    {
        [TestMethod]
        public void MoneyIsWithdrawnFromPayerAfterTransfer()
        {
            // Arrange
            Account payee = new Account
            {
                Balance = new MoneyAmount(12500),
                Id = 1,
                Transactions = new List<Transaction>()
            };

            Account payor = new Account
            {
                Balance = new MoneyAmount(12500),
                Id = 1,
                Transactions = new List<Transaction>()
            };

            // Act
            payor.TransferTo(payee, new MoneyAmount(1000m));

            // Assert
            var expected = new MoneyAmount(11500);
            Assert.AreEqual(expected, payor.Balance);
        }

        [TestMethod]
        public void MoneyIsDepositToPayeeAfterTransfer()
        {
            // Arrange
            Account payee = new Account
            {
                Balance = new MoneyAmount(12500),
                Id = 1,
                Transactions = new List<Transaction>()
            };

            Account payor = new Account
            {
                Balance = new MoneyAmount(12500),
                Id = 1,
                Transactions = new List<Transaction>()
            };

            // Act
            payor.TransferTo(payee, new MoneyAmount(1000m));

            // Assert
            var expected = new MoneyAmount(13500);
            Assert.AreEqual(expected, payee.Balance);
        }
    }
}
