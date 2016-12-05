using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTestBankWebApplicationWithoutUsers.Models
{
    public class Account : Entity<int>
    {
        public int Id { get; set; }
        public MoneyAmount Balance { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public AccountState State { get; set; }

        public Account()
        {
            this.State = AccountState.OpenState;
        }
    }
}
