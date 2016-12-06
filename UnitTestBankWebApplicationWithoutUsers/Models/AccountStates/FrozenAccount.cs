using System;

namespace UnitTestBankWebApplicationWithoutUsers.Models.AccountStates
{
    public class FrozenAccount : AccountState
    {
        public override void Deposit(Action deposit)    => deposit();
        public override void Withdraw(Action withdraw) { }
        public override AccountState Freeze()           => this;
    }
}