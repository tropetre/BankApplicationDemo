using System;
using System.ComponentModel.DataAnnotations;

namespace UnitTestBankWebApplicationWithoutUsers.Models
{
    public class Transaction : Entity<int>
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public decimal MoneyAmount { get; }

        [Required]
        public virtual DateTime Date { get; }

        [Required]
        public Account Account { get; set; }

        [Required]
        public virtual TransactionType Type { get; }

        public Transaction()
        {

        }
        
        public Transaction(decimal amount, TransactionType type)
        {
            this.Date = DateTime.Now;
            this.MoneyAmount = amount;
            this.Type = type;
        }
    }
}
