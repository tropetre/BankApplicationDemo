using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnitTestBankWebApplicationWithoutUsers.Models.AccountStates
{
    public class Active : AccountState
    {
        public override void Deposit(Action deposit)     => deposit();
        public override void Withdraw(Action withdraw)   => withdraw();
        public override AccountState Freeze()            => new Frozen();
    }
}