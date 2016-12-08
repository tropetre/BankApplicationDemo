using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnitTestBankWebApplicationWithoutUsers.Models
{
    using AccountStates;

    public class Account : Entity<int>
    {
        [Key, DisplayName("Account-Id")]
        public int Id { get; set; }

        public virtual Person Owner { get; set; }

        [Required, ForeignKey("Owner"), DisplayName("Social Security Number")]
        public string Owner_Id { get; set; }

        private AccountState _state = StateFactory.GetState(AccountStateType.Active);
        
        [Required, DisplayName("Account Status")]
        public AccountStateType State
        {
            get
            {
                return _state.GetStateType();
            }
            set
            {
                _state = StateFactory.GetState(value);

            }
        }

        [Required]
        public decimal Balance { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
        
        public void Withdraw(decimal amount) =>
            _state.Withdraw(() => 
            {
                Balance -= amount;
                Transactions.Add(
                    new Transaction(amount, TransactionType.Withdrawal));
            });

        public void Deposit(decimal amount) =>
            _state.Deposit(() => 
            {
                Balance += amount;
                Transactions.Add(
                    new Transaction(amount, TransactionType.Deposit));
            });

        public void TransferTo(Account payee, decimal amount) =>
            _state.Withdraw(() =>
            {
                Balance -= amount;
                Transactions.Add(
                    new Transaction(amount, TransactionType.Deacquisition));

                payee.Acquire(amount: amount, payor: this);
            });

        private void Acquire(decimal amount, Account payor) =>
            _state.Deposit(() => 
            {
                Balance += amount;
                Transactions.Add(
                    new Transaction(amount, TransactionType.Acquisition));
            });

        public void Freeze() => _state = _state.Freeze();
    }
}
