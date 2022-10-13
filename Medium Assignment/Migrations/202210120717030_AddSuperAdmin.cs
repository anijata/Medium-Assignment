namespace Medium_Assignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSuperAdmin : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'520d1b4d-dce8-4f24-a7c2-6a7095603a7b', N'admin@issq.com', 0, N'AO9DbkvoXHRaVDEfzxYBFmlAO8ncktCz/Yvrxs8iuibZLI6P6QQ6R3siEFhcr04KUg==', N'b92f42c2-8877-461d-97a7-d6d4655f862b', N'911', 0, 0, NULL, 1, 0, N'admin')");
            Sql(@"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'8fc25acd-cd2f-4756-91c7-0f9ce39882dc', N'OrganizationAdmin')");
            Sql(@"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'0da3f006-ea96-4158-80fd-5b555b08ad29', N'SuperAdmin')");
        }
        
        public override void Down()
        {
        }
    }
}
