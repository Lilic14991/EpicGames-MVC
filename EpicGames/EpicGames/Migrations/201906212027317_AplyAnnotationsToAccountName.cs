namespace EpicGames.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AplyAnnotationsToAccountName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Accounts", "AName", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Accounts", "AName", c => c.String());
        }
    }
}
