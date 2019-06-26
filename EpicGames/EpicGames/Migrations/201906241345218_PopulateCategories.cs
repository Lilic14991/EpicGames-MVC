namespace EpicGames.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCategories : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categories(CName) VALUES('MMORPG')");
            Sql("INSERT INTO Categories(CName) VALUES('RPG')");
            Sql("INSERT INTO Categories(CName) VALUES('MOBA')");
            Sql("INSERT INTO Categories(CName) VALUES('FPS')");
            Sql("INSERT INTO Categories(CName) VALUES('RTS')");
        }
        
        public override void Down()
        {
        }
    }
}
