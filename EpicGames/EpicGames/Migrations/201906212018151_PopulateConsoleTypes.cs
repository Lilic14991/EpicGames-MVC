namespace EpicGames.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateConsoleTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO ConsoleTypes(ConsoleTypeID,CName,SignUpFee,DurationInMonths) VALUES(1,'PC',0,0)");
            Sql("INSERT INTO ConsoleTypes(ConsoleTypeID,CName,SignUpFee,DurationInMonths) VALUES(2,'Ps4',55,6)");
            Sql("INSERT INTO ConsoleTypes(ConsoleTypeID,CName,SignUpFee,DurationInMonths) VALUES(3,'xBox',60,4)");
            Sql("INSERT INTO ConsoleTypes(ConsoleTypeID,CName,SignUpFee,DurationInMonths) VALUES(4,'xBox One',65,2)");
            Sql("INSERT INTO ConsoleTypes(ConsoleTypeID,CName,SignUpFee,DurationInMonths) VALUES(5,'Ps5',70,1)");
        }
        
        public override void Down()
        {
        }
    }
}
