namespace SocialGames.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Refactoring_Player : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Game", "Player_Id", "dbo.Player");
            DropForeignKey("dbo.PlatForm", "Player_Id", "dbo.Player");
            DropIndex("dbo.Game", new[] { "Player_Id" });
            DropIndex("dbo.PlatForm", new[] { "Player_Id" });
            DropColumn("dbo.Game", "Player_Id");
            DropColumn("dbo.PlatForm", "Player_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PlatForm", "Player_Id", c => c.Guid());
            AddColumn("dbo.Game", "Player_Id", c => c.Guid());
            CreateIndex("dbo.PlatForm", "Player_Id");
            CreateIndex("dbo.Game", "Player_Id");
            AddForeignKey("dbo.PlatForm", "Player_Id", "dbo.Player", "Id");
            AddForeignKey("dbo.Game", "Player_Id", "dbo.Player", "Id");
        }
    }
}
