namespace Medium_Assignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReviewTableChanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reviews", "Agenda", c => c.String());
            AlterColumn("dbo.Reviews", "Description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reviews", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Reviews", "Agenda", c => c.String(nullable: false));
        }
    }
}
