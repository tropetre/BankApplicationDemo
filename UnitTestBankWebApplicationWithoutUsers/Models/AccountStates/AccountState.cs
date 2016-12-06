using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTestBankWebApplicationWithoutUsers.Models.AccountStates
{
    public interface AccountState
    {
        void Deposit(Action deposit);
        void Withdraw(Action withdraw);
    }
}
