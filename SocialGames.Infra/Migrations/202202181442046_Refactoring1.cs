namespace SocialGames.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Refactoring1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Game", "Player_Id", c => c.Guid());
            AddColumn("dbo.PlatForm", "Player_Id", c => c.Guid());
            CreateIndex("dbo.Game", "Player_Id");
            CreateIndex("dbo.PlatForm", "Player_Id");
            AddForeignKey("dbo.Game", "Player_Id", "dbo.Player", "Id");
            AddForeignKey("dbo.PlatForm", "Player_Id", "dbo.Player", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlatForm", "Player_Id", "dbo.Player");
            DropForeignKey("dbo.Game", "Player_Id", "dbo.Player");
            DropIndex("dbo.PlatForm", new[] { "Player_Id" });
            DropIndex("dbo.Game", new[] { "Player_Id" });
            DropColumn("dbo.PlatForm", "Player_Id");
            DropColumn("dbo.Game", "Player_Id");
        }
    }
}
