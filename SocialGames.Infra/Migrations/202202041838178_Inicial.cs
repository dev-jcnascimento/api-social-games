namespace SocialGames.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Game", t => t.GameId)
                .ForeignKey("dbo.PlatForm", t => t.PlatForm_Id)
                .Index(t => t.GameId)
                .Index(t => t.PlatForm_Id);
            
            CreateTable(
                "dbo.Game",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        Description = c.String(nullable: false, maxLength: 200, unicode: false),
                        Producer = c.String(nullable: false, maxLength: 50, unicode: false),
                        Gender = c.String(nullable: false, maxLength: 50, unicode: false),
                        Distributor = c.String(nullable: false, maxLength: 50, unicode: false),
                        PlatFormId = c.Guid(nullable: false),
                        Player_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PlatForm", t => t.PlatFormId)
                .ForeignKey("dbo.Player", t => t.Player_Id)
                .Index(t => t.PlatFormId)
                .Index(t => t.Player_Id);
            
            CreateTable(
                "dbo.PlatForm",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        Player_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Player", t => t.Player_Id)
                .Index(t => t.Player_Id);
            
            CreateTable(
                "dbo.MyGames",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        GameStatus = c.Int(name: "Game Status", nullable: false),
                        PlayerId = c.Guid(nullable: false),
                        GameId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Game", t => t.GameId)
                .ForeignKey("dbo.Player", t => t.PlayerId)
                .Index(t => t.PlayerId)
                .Index(t => t.GameId);
            
            CreateTable(
                "dbo.Player",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50, unicode: false),
                        LastName = c.String(nullable: false, maxLength: 50, unicode: false),
                        Email = c.String(nullable: false, maxLength: 200, unicode: false),
                        Password = c.String(nullable: false, maxLength: 100, unicode: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Email, unique: true, name: "UK_PLAYER_EMAIL");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MyGames", "PlayerId", "dbo.Player");
            DropForeignKey("dbo.PlatForm", "Player_Id", "dbo.Player");
            DropForeignKey("dbo.Game", "Player_Id", "dbo.Player");
            DropForeignKey("dbo.MyGames", "GameId", "dbo.Game");
            DropForeignKey("dbo.GamePlatForm", "PlatForm_Id", "dbo.PlatForm");
            DropForeignKey("dbo.GamePlatForm", "GameId", "dbo.Game");
            DropForeignKey("dbo.Game", "PlatFormId", "dbo.PlatForm");
            DropIndex("dbo.Player", "UK_PLAYER_EMAIL");
            DropIndex("dbo.MyGames", new[] { "GameId" });
            DropIndex("dbo.MyGames", new[] { "PlayerId" });
            DropIndex("dbo.PlatForm", new[] { "Player_Id" });
            DropIndex("dbo.Game", new[] { "Player_Id" });
            DropIndex("dbo.Game", new[] { "PlatFormId" });
            DropIndex("dbo.GamePlatForm", new[] { "PlatForm_Id" });
            DropIndex("dbo.GamePlatForm", new[] { "GameId" });
            DropTable("dbo.Player");
            DropTable("dbo.MyGames");
            DropTable("dbo.PlatForm");
            DropTable("dbo.Game");
            DropTable("dbo.GamePlatForm");
        }
    }
}
