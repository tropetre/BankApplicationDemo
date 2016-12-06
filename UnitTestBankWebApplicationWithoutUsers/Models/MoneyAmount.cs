using System;

namespace UnitTestBankWebApplicationWithoutUsers.Models
{
    public sealed class MoneyAmount : IEquatable<MoneyAmount>
    {
        public decimal Amount { get; }

        public MoneyAmount(decimal amount)
        {
            this.Amount = amount;
        }

        public override string ToString() =>
            $"{this.Amount} Moneys.";

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is MoneyAmount))
                return false;

            var other = obj as MoneyAmount;

            return Amount == other.Amount;
        }

        public bool Equals(MoneyAmount other) =>
            this.Amount == other.Amount ? true : false;

        public static bool operator ==(MoneyAmount a, MoneyAmount b) =>
            a != null ^ b != null && a.Amount == b.Amount;

        public static bool operator !=(MoneyAmount a, MoneyAmount b) =>
            !(a == b);

        public static MoneyAmount operator -(MoneyAmount amount, MoneyAmount difference) =>
            new MoneyAmount(amount.Amount - difference.Amount);

        public static MoneyAmount operator +(MoneyAmount amount, MoneyAmount difference) =>
            new MoneyAmount(amount.Amount + difference.Amount);

        public override int GetHashCode()
        {
            return Amount.GetHashCode();
        }
    }
}