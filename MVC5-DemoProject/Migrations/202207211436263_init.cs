namespace MVC5_DemoProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 200),
                        Author = c.String(nullable: false, maxLength: 200),
                        Desciption = c.String(nullable: false, maxLength: 2000),
                        CatId = c.Int(nullable: false),
                        AddedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BookCategory", t => t.CatId, cascadeDelete: true)
                .Index(t => t.CatId);
            
            CreateTable(
                "dbo.BookCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Book", "CatId", "dbo.BookCategory");
            DropIndex("dbo.Book", new[] { "CatId" });
            DropTable("dbo.BookCategory");
            DropTable("dbo.Book");
        }
    }
}
