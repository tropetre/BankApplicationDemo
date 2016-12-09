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
        public DateTime Date { get; set; }

        [Required]
        public virtual Account Account { get; set; }

        [Required]
        public TransactionType Type { get; set; }

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
