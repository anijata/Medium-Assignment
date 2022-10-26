namespace Medium_Assignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectedReviewTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReviewsEmployees", "IsDeleted", c => c.Boolean(nullable: false));
            DropColumn("dbo.Reviews", "Rating");
            DropColumn("dbo.Reviews", "Feedback");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reviews", "Feedback", c => c.String());
            AddColumn("dbo.Reviews", "Rating", c => c.Int(nullable: false));
            DropColumn("dbo.ReviewsEmployees", "IsDeleted");
        }
    }
}
