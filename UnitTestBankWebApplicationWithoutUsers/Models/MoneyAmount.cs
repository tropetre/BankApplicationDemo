using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnitTestBankWebApplicationWithoutUsers.Models.Exceptions;

namespace UnitTestBankWebApplicationWithoutUsers.Models
{
    public sealed class MoneyAmount : IEquatable<MoneyAmount>
    {
        public Currency Currency { get; }
        public decimal Amount { get; }

        public MoneyAmount(decimal amount, Currency currency)
        {
            this.Amount = amount;
            this.Currency = currency;
        }

        public bool Equals(MoneyAmount other) =>
            this.Amount == other.Amount && this.Currency == other.Currency ? true : false;

        public override string ToString() =>
            $"{this.Amount} {this.Currency}s.";

        public static MoneyAmount operator -(MoneyAmount amount, MoneyAmount difference)
        {
            if(amount.Currency != difference.Currency)
                throw new CurrencyConversionException();

            return new MoneyAmount(amount.Amount - difference.Amount, amount.Currency);
        }
    }
}