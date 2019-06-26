namespace EpicGames.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyGameModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "CategoryID", c => c.Int(nullable: false));
            AddColumn("dbo.Games", "PGame", c => c.Int(nullable: false));
            CreateIndex("dbo.Games", "CategoryID");
            AddForeignKey("dbo.Games", "CategoryID", "dbo.Categories", "CategoryID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Games", new[] { "CategoryID" });
            DropColumn("dbo.Games", "PGame");
            DropColumn("dbo.Games", "CategoryID");
        }
    }
}
