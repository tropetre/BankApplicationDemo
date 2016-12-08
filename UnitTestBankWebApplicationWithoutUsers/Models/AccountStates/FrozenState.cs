using System;

namespace UnitTestBankWebApplicationWithoutUsers.Models.AccountStates
{
    public class FrozenState : AccountState
    {
        public override void Deposit(Action deposit)    => deposit();
        public override void Withdraw(Action withdraw) { }
        public override AccountState Freeze()           => this;
        public override AccountStateType GetStateType() => AccountStateType.Frozen;
    }
}