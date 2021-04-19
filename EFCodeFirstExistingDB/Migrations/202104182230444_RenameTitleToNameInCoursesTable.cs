namespace EFCodeFirstExistingDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameTitleToNameInCoursesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Name", c => c.String(nullable: false, maxLength: 255, unicode: false));
            Sql("Update dbo.Courses SET Name = Title");
            DropColumn("dbo.Courses", "Title");
           
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "Title", c => c.String(nullable: false, maxLength: 255, unicode: false));
            Sql("Update dbo.Courses SET Title = Name");
            DropColumn("dbo.Courses", "Name");
        }
    }
}
