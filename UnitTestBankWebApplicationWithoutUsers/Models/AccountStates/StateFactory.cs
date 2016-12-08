using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace UnitTestBankWebApplicationWithoutUsers.Models.AccountStates
{
    public static class StateFactory
    {
        private static Dictionary<AccountStateType, AccountState> statesCache = FindAllDerivedStates();

        public static AccountState GetState(AccountStateType stateType) => statesCache[stateType];

        private static Dictionary<AccountStateType, AccountState> FindAllDerivedStates() => 
            Assembly.GetAssembly(typeof(AccountState)).GetTypes()
                .Where(t => t != typeof(AccountState) && typeof(AccountState).IsAssignableFrom(t))
                .Select(t => (AccountState)Activator.CreateInstance(t))
                .ToDictionary(k => k.GetStateType());
    }
}