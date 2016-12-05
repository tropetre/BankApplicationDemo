using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestBankWebApplicationWithoutUsers.Models
{
    public interface Transaction
    {
        public int Id;
        public MoneyAmount MoneyAmount;
        public DateTime Date;
    }
}
