namespace Medium_Assignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedCountriesStatesCities : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO dbo.Countries (Name) VALUES ('USA'), ('India'), ('Australia')");
            Sql(@"INSERT INTO dbo.States (Name, CountryId) VALUES ('California', 1), ('Ohio', 1), ('Texas', 1)");
            Sql(@"INSERT INTO dbo.States (Name, CountryId) VALUES ('Telangana', 2), ('Andhra Pradesh', 2), ('New South Wales', 3)");
            Sql(@"INSERT INTO dbo.States (Name, CountryId) VALUES ('Victoria', 3), ('Queensland', 3)");
            Sql(@"INSERT INTO dbo.Cities (Name, StateId) VALUES ('Los Angeles', 1), ('San Diego', 1),('Columbus', 2)");
            Sql(@"INSERT INTO dbo.Cities (Name, StateId) VALUES ('Cleveland', 2), ('Houston', 3), ('Dallas', 3)");
            Sql(@"INSERT INTO dbo.Cities (Name, StateId) VALUES ('Hyderabad', 4), ('Karimnagar', 4), ('Visakhapatnam', 5)");
            Sql(@"INSERT INTO dbo.Cities (Name, StateId) VALUES ('Melbourne', 7), ('Mildura', 7), ('Brisbane', 8), ('Mackay', 8)");
        }
        
        public override void Down()
        {
        }
    }
}
