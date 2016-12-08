using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UnitTestBankWebApplicationWithoutUsers.Models;

namespace UnitTestBankWebApplicationWithoutUsers.DataAccess
{
    public class BankContext : DbContext
    {
        public BankContext() : base("DefaultConnection")
        {

        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Person> People { get; set; }
    }
}