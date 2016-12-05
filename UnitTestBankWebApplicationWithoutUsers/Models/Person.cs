using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UnitTestBankWebApplicationWithoutUsers.Models
{
    public class Person
    {
        [Key]
        public string Id { get; set; }
        public string FullName { get; set; }
        ICollection<Account> Accounts { get; set; }
    }
}