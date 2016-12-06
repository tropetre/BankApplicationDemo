using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UnitTestBankWebApplicationWithoutUsers.Models.AccountStates;

namespace UnitTestBankWebApplicationWithoutUsers.Models
{
    public class Account : Entity<int>
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public virtual Person Owner { get; set; }
        public MoneyAmount Balance { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
        public AccountState State { get; set; } = new Active();
        
        public void Withdraw(MoneyAmount amount) =>
            this.State.Withdraw(() => 
            {
                this.Balance -= amount;
                this.Transactions.Add(
                    new Transaction(amount, TransactionType.Withdrawal));
            });

        public void Deposit(MoneyAmount amount) =>
            this.State.Deposit(() => 
            {
                this.Balance += amount;
                this.Transactions.Add(
                    new Transaction(amount, TransactionType.Deposit));
            });

        public void TransferTo(Account payee, MoneyAmount amount) =>
            this.State.Withdraw(() =>
            {
                this.Balance -= amount;
                this.Transactions.Add(
                    new Transaction(amount, TransactionType.Deacquisition));

                payee.Acquire(amount: amount, payor: this);
            });

        private void Acquire(MoneyAmount amount, Account payor) =>
            this.State.Deposit(() => 
            {
                this.Balance += amount;
                this.Transactions.Add(
                    new Transaction(amount, TransactionType.Acquisition));
            });

        public void Freeze() => this.State = this.State.Freeze();
    }
}
