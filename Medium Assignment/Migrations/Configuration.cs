﻿namespace Medium_Assignment.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Medium_Assignment.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Medium_Assignment.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Medium_Assignment.Models.ApplicationDbContext";
        }

        protected override void Seed(Medium_Assignment.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.


        }

    }
}
