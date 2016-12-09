using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace UnitTestBankWebApplicationWithoutUsers.Models
{
    public class TransactionViewModel
    {
        [Required, DisplayName("From Account")]
        public int From_Id { get; set; }

        [Required, DisplayName("To Account")]
        public int To_Id { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public IEnumerable<Account> Accounts { get; set; }
    }
}