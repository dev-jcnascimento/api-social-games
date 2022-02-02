namespace SocialGames.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GamePlatForm : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GamePlatForm",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Game_Id = c.Guid(),
                        Platform_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Game", t => t.Game_Id)
                .ForeignKey("dbo.PlatForm", t => t.Platform_Id)
                .Index(t => t.Game_Id)
                .Index(t => t.Platform_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GamePlatForm", "Platform_Id", "dbo.PlatForm");
            DropForeignKey("dbo.GamePlatForm", "Game_Id", "dbo.Game");
            DropIndex("dbo.GamePlatForm", new[] { "Platform_Id" });
            DropIndex("dbo.GamePlatForm", new[] { "Game_Id" });
            DropTable("dbo.GamePlatForm");
        }
    }
}
