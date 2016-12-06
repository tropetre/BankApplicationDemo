﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnitTestBankWebApplicationWithoutUsers.Models.AccountStates
{
    public class Active : AccountState
    {
        public void Deposit(Action deposit)
        {
            deposit();
        }

        public void Withdraw(Action withdraw)
        {
            withdraw();
        }
    }
}