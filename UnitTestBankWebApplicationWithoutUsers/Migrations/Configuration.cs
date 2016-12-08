namespace UnitTestBankWebApplicationWithoutUsers.Migrations
{
    using Models;
    using System.Data.Entity.Migrations;
    using DataAccess;

    internal sealed class Configuration : DbMigrationsConfiguration<BankContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BankContext context)
        {
            context.People.AddOrUpdate(
                p => p.Id,
                new Person { Id = "840304-8203", FullName = "Andrew Peters" },
                new Person { Id = "811124-1658", FullName = "Brice Lambson" },
                new Person { Id = "940505-7569", FullName = "Rowan Miller" }
            );

            var i = 1;
            context.Accounts.AddOrUpdate(
                a => a.Id,
                new Account { Id = i++, Balance = 12500m,  Owner_Id = "840304-8203" },
                new Account { Id = i++, Balance = 13500m,  Owner_Id = "840304-8203" },
                new Account { Id = i++, Balance = 12200m,  Owner_Id = "840304-8203" },
                new Account { Id = i++, Balance = 100m,    Owner_Id = "811124-1658" },
                new Account { Id = i++, Balance = 322500m, Owner_Id = "811124-1658" },
                new Account { Id = i++, Balance = 62500m,  Owner_Id = "940505-7569" }
            );
        }
    }
}
