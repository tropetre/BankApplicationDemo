using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UnitTestBankWebApplicationWithoutUsers.Models
{
    public class Person : Entity<string>
    {
        [Key]
        public string Id { get; set; }
        public string FullName { get; set; }
        ICollection<Account> Accounts { get; set; }
    }
}