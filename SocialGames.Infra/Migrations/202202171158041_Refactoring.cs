namespace SocialGames.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Refactoring : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GamePlatForm", "GameId", "dbo.Game");
            DropForeignKey("dbo.GamePlatForm", "PlatForm_Id", "dbo.PlatForm");
            DropIndex("dbo.GamePlatForm", new[] { "GameId" });
            DropIndex("dbo.GamePlatForm", new[] { "PlatForm_Id" });
            DropTable("dbo.GamePlatForm");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.GamePlatForm",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        GameId = c.Guid(nullable: false),
                        PlatForm_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.GamePlatForm", "PlatForm_Id");
            CreateIndex("dbo.GamePlatForm", "GameId");
            AddForeignKey("dbo.GamePlatForm", "PlatForm_Id", "dbo.PlatForm", "Id");
            AddForeignKey("dbo.GamePlatForm", "GameId", "dbo.Game", "Id");
        }
    }
}
