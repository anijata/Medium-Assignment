namespace Medium_Assignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectedReviewTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "EmployeeId", c => c.Int());
            CreateIndex("dbo.Reviews", "EmployeeId");
            AddForeignKey("dbo.Reviews", "EmployeeId", "dbo.Employees", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Reviews", new[] { "EmployeeId" });
            DropColumn("dbo.Reviews", "EmployeeId");
        }
    }
}
