using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestBankWebApplicationWithoutUsers.Models
{
    public interface Transaction
    {
        int Id { get; set; }
        MoneyAmount MoneyAmount { get; set; }
        DateTime Date { get; set; }
    }
}
