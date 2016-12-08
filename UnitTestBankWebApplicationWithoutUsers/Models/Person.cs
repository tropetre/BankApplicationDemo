using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UnitTestBankWebApplicationWithoutUsers.Models
{
    public class Person : Entity<string>
    {
        [Key, DisplayName("SSN")]
        public string Id { get; set; }

        [DisplayName("Full Name")]
        public string FullName { get; set; }

        public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
    }
}