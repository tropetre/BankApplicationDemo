using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnitTestBankWebApplicationWithoutUsers.Models.AccountStates
{
    public class Frozen : AccountState
    {
        public override void Deposit(Action deposit) => deposit();
        public override void Withdraw(Action withdraw) { }
        public override AccountState Freeze() => this;
    }
}