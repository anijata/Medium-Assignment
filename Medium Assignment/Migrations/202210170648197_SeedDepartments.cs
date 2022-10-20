namespace Medium_Assignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedDepartments : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[Departments] ([Name]) VALUES ('Department 1'), ('Department 2'), ('Department 3')");
        }
        
        public override void Down()
        {
        }
    }
}
