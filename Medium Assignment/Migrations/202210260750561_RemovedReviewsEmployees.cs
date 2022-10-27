namespace Medium_Assignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedReviewsEmployees : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ReviewsEmployees", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.ReviewsEmployees", "ReviewId", "dbo.Reviews");
            DropIndex("dbo.ReviewsEmployees", new[] { "ReviewId" });
            DropIndex("dbo.ReviewsEmployees", new[] { "EmployeeId" });
            AddColumn("dbo.Reviews", "Rating", c => c.Int(nullable: false));
            AddColumn("dbo.Reviews", "Feedback", c => c.String());
            AddColumn("dbo.Reviews", "EmployeeId", c => c.Int());
            CreateIndex("dbo.Reviews", "EmployeeId");
            AddForeignKey("dbo.Reviews", "EmployeeId", "dbo.Employees", "Id");
            DropTable("dbo.ReviewsEmployees");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ReviewsEmployees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReviewId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                        Feedback = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Reviews", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Reviews", new[] { "EmployeeId" });
            DropColumn("dbo.Reviews", "EmployeeId");
            DropColumn("dbo.Reviews", "Feedback");
            DropColumn("dbo.Reviews", "Rating");
            CreateIndex("dbo.ReviewsEmployees", "EmployeeId");
            CreateIndex("dbo.ReviewsEmployees", "ReviewId");
            AddForeignKey("dbo.ReviewsEmployees", "ReviewId", "dbo.Reviews", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ReviewsEmployees", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
        }
    }
}
