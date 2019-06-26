namespace EpicGames.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            AddColumn("dbo.Games", "GYear", c => c.Int(nullable: false));
            AddColumn("dbo.Games", "GFor", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Games", "GFor");
            DropColumn("dbo.Games", "GYear");
            DropTable("dbo.Categories");
        }
    }
}
