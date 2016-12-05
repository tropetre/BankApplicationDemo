using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnitTestBankWebApplicationWithoutUsers.Models
{
    public class MoneyAmount
    {
        public Currency Currency { get; set; }
        public decimal Amount { get; set; }
    }
}