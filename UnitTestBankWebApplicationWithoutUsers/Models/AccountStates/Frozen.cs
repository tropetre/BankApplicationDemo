using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnitTestBankWebApplicationWithoutUsers.Models.AccountStates
{
    public class Frozen : AccountState
    {
        public void Deposit(Action deposit)
        {
        }

        public void Withdraw(Action withdraw)
        {
        }
    }
}