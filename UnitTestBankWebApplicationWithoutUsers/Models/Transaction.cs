using System;
using System.ComponentModel.DataAnnotations;

namespace UnitTestBankWebApplicationWithoutUsers.Models
{
    public class Transaction : Entity<int>
    {
        [Key]
        public int Id { get; set; }
        public virtual MoneyAmount MoneyAmount { get; }
        public virtual DateTime Date { get; }
        public virtual TransactionType Type { get; }

        public Transaction()
        {

        }
        
        public Transaction(MoneyAmount amount, TransactionType type)
        {
            this.Date = DateTime.Now;
            this.MoneyAmount = amount;
            this.Type = type;
        }
    }
}
