namespace CustomerLog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Logs", "PhoneNumber", c => c.String());
            AddColumn("dbo.Logs", "MessageSummary", c => c.String());
            AddColumn("dbo.Logs", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Logs", "Discriminator");
            DropColumn("dbo.Logs", "MessageSummary");
            DropColumn("dbo.Logs", "PhoneNumber");
        }
    }
}
