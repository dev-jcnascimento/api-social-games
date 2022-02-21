namespace SocialGames.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Refactoring_3 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.MyGames", newName: "MyGame");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.MyGame", newName: "MyGames");
        }
    }
}
