using System;

namespace UnitTestBankWebApplicationWithoutUsers.Models.AccountStates
{
    public class ActiveState : AccountState
    {
        public override void Deposit(Action deposit)     => deposit();
        public override void Withdraw(Action withdraw)   => withdraw();
        public override AccountState Freeze()            => StateFactory.GetState(AccountStateType.Frozen);
        public override AccountStateType GetStateType()  => AccountStateType.Active;
    }
}