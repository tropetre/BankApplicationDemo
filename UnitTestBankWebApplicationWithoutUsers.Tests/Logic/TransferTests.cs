using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestBankWebApplicationWithoutUsers.Models;
using System.Collections.Generic;
using UnitTestBankWebApplicationWithoutUsers.Models.AccountStates;

namespace UnitTestBankWebApplicationWithoutUsers.Tests.TransferTests
{
    [TestClass]
    public class TransferTests
    {
        [TestMethod]
        public void ActiveAccountsCanTransferMoney()
        {
            // Arrange
            Account payee = new Account
            {
                Balance = new decimal(12500),
                Id = 1
            };

            Account payor = new Account
            {
                Balance = new decimal(12500),
                Id = 2
            };

            // Act
            payor.TransferTo(payee, new decimal(1000));

            // Assert
            var payorExpected = new decimal(11500);
            Assert.AreEqual(payorExpected, payor.Balance);

            var payeeExpected = new decimal(13500);
            Assert.AreEqual(payeeExpected, payee.Balance);
        }

        [TestMethod]
        public void FrozenAccountCanNotTransferMoney()
        {
            // Arrange
            Account payee = new Account
            {
                Balance = new decimal(12500),
                Id = 1,
                State = AccountStateType.Frozen
            };

            Account payor = new Account
            {
                Balance = new decimal(12500),
                Id = 2,
                State = AccountStateType.Frozen
            };

            // Act
            payor.TransferTo(payee, new decimal(1000));

            // Assert
            var expected = new decimal(12500);
            Assert.AreEqual(expected, payor.Balance);

            expected = new decimal(12500);
            Assert.AreEqual(expected, payee.Balance);
        }
    }
}
