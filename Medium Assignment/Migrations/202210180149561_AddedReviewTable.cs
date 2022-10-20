namespace Medium_Assignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedReviewTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReviewStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Reviews", "ReviewStatusId", c => c.Int(nullable: false));
            CreateIndex("dbo.Reviews", "ReviewStatusId");
            AddForeignKey("dbo.Reviews", "ReviewStatusId", "dbo.ReviewStatus", "Id", cascadeDelete: false);

            Sql(@"INSERT INTO [dbo].[ReviewStatus] ([Name]) VALUES ('New'), ('Assigned'), ('Submitted')");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "ReviewStatusId", "dbo.ReviewStatus");
            DropIndex("dbo.Reviews", new[] { "ReviewStatusId" });
            DropColumn("dbo.Reviews", "ReviewStatusId");
            DropTable("dbo.ReviewStatus");
        }
    }
}
