using System;

namespace UnitTestBankWebApplicationWithoutUsers.Models.AccountStates
{
    public class ActiveAccount : AccountState
    {
        public override void Deposit(Action deposit)     => deposit();
        public override void Withdraw(Action withdraw)   => withdraw();
        public override AccountState Freeze()            => new FrozenAccount();
    }
}