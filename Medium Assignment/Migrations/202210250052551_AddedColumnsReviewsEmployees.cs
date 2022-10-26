namespace Medium_Assignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedColumnsReviewsEmployees : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReviewsEmployees", "Rating", c => c.Int(nullable: false));
            AddColumn("dbo.ReviewsEmployees", "Feedback", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ReviewsEmployees", "Feedback");
            DropColumn("dbo.ReviewsEmployees", "Rating");
        }
    }
}
