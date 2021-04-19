namespace EFCodeFirstExistingDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class DeleteCategoryTable : DbMigration
    {
        public override void Up()
        {
            //Create tmp table to preserve data
            //You could use Sql("Create Table ...") or use builtin helper method like this.
            CreateTable(
                    "dbo._Categories",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            Sql("Insert Into dbo._Categories (Name) Select Name from dbo.Categories");
            //finally drop source table
            DropTable("dbo.Categories");
        }

        public override void Down()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.Id);

            // pullout data from _Categories
            Sql("Insert Into dbo.Categories (Name) Select Name from dbo._Categories");
            //drop temp table
            DropTable("dbo._Categories");

        }
    }
}
