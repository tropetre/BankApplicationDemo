namespace UnitTestBankWebApplicationWithoutUsers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StateType = c.Int(nullable: false),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Owner_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Owner_Id, cascadeDelete: true)
                .Index(t => t.Owner_Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Account_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.Account_Id, cascadeDelete: true)
                .Index(t => t.Account_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "Account_Id", "dbo.Accounts");
            DropForeignKey("dbo.Accounts", "Owner_Id", "dbo.People");
            DropIndex("dbo.Transactions", new[] { "Account_Id" });
            DropIndex("dbo.Accounts", new[] { "Owner_Id" });
            DropTable("dbo.Transactions");
            DropTable("dbo.People");
            DropTable("dbo.Accounts");
        }
    }
}
