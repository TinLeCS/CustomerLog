namespace CustomerLog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEmailLog : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Logs", "Email", c => c.String());
            AddColumn("dbo.Logs", "Subject", c => c.String());
            AddColumn("dbo.Logs", "Text", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Logs", "Text");
            DropColumn("dbo.Logs", "Subject");
            DropColumn("dbo.Logs", "Email");
        }
    }
}
