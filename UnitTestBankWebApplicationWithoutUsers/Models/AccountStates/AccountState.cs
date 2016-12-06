using System;

namespace UnitTestBankWebApplicationWithoutUsers.Models.AccountStates
{
    public abstract class AccountState
    {
        public abstract void Deposit(Action deposit);
        public abstract void Withdraw(Action withdraw);
        public abstract AccountState Freeze();
    }
}
