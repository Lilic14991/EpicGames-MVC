namespace EpicGames.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeBuyModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Buys",
                c => new
                    {
                        BuyID = c.Int(nullable: false, identity: true),
                        AccountID = c.Int(nullable: false),
                        GameID = c.Int(nullable: false),
                        BuyDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BuyID)
                .ForeignKey("dbo.Accounts", t => t.AccountID, cascadeDelete: true)
                .ForeignKey("dbo.Games", t => t.GameID, cascadeDelete: true)
                .Index(t => t.AccountID)
                .Index(t => t.GameID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Buys", "GameID", "dbo.Games");
            DropForeignKey("dbo.Buys", "AccountID", "dbo.Accounts");
            DropIndex("dbo.Buys", new[] { "GameID" });
            DropIndex("dbo.Buys", new[] { "AccountID" });
            DropTable("dbo.Buys");
        }
    }
}
