using System.Collections.Generic;

namespace EFCodeFirstExistingDB.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EFCodeFirstExistingDB.PlutoDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EFCodeFirstExistingDB.PlutoDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            //check if author is already present with same name , if yes then update else add 
            context.Authors.AddOrUpdate(a => a.Name, new Author()
            {
                Name = "Babai",
                Courses = new List<Course>()
                {
                    new Course() {Name = "React JS", FullPrice = 150, Description = "React js"},
                    new Course() {Name = "Asp.net MVC", FullPrice = 154, Description = "Mvc"}
                }
            });
        }
    }
}
