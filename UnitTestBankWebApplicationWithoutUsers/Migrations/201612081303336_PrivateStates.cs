namespace UnitTestBankWebApplicationWithoutUsers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrivateStates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "State", c => c.Int(nullable: false));
            DropColumn("dbo.Accounts", "StateType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Accounts", "StateType", c => c.Int(nullable: false));
            DropColumn("dbo.Accounts", "State");
        }
    }
}
