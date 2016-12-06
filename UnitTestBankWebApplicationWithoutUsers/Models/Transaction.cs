using System;

namespace UnitTestBankWebApplicationWithoutUsers.Models
{
    public class Transaction
    {
        public virtual MoneyAmount MoneyAmount { get; }
        public virtual DateTime Date { get; }
        public virtual TransactionType Type { get; }

        public Transaction(MoneyAmount amount, TransactionType type)
        {
            this.Date = DateTime.Now;
            this.MoneyAmount = amount;
            this.Type = type;
        }
    }
}
