using System;

namespace UnitTestBankWebApplicationWithoutUsers.Models.Exceptions
{
    public class CurrencyConversionException : Exception
    {
        public CurrencyConversionException()
        {
        }

        public CurrencyConversionException(string message) : base(message)
        {
        }

        public CurrencyConversionException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}