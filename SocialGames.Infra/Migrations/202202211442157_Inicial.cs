namespace SocialGames.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Description = c.String(nullable: false, maxLength: 500, unicode: false),
                        GameId = c.Guid(nullable: false),
                        PlayerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Game", t => t.GameId)
                .ForeignKey("dbo.Player", t => t.PlayerId)
                .Index(t => t.GameId)
                .Index(t => t.PlayerId);
            
            CreateTable(
                "dbo.Game",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100, unicode: false),
                        Description = c.String(nullable: false, maxLength: 200, unicode: false),
                        Producer = c.String(nullable: false, maxLength: 100, unicode: false),
                        Gender = c.String(nullable: false, maxLength: 100, unicode: false),
                        Distributor = c.String(nullable: false, maxLength: 100, unicode: false),
                        PlatFormId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PlatForm", t => t.PlatFormId)
                .Index(t => t.PlatFormId);
            
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
                .ForeignKey("dbo.Player", t => t.PlayerId)
                .ForeignKey("dbo.Game", t => t.GameId)
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
            
            CreateTable(
                "dbo.PlatForm",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Game", "PlatFormId", "dbo.PlatForm");
            DropForeignKey("dbo.MyGames", "GameId", "dbo.Game");
            DropForeignKey("dbo.MyGames", "PlayerId", "dbo.Player");
            DropForeignKey("dbo.Comment", "PlayerId", "dbo.Player");
            DropForeignKey("dbo.Comment", "GameId", "dbo.Game");
            DropIndex("dbo.Player", "UK_PLAYER_EMAIL");
            DropIndex("dbo.MyGames", new[] { "GameId" });
            DropIndex("dbo.MyGames", new[] { "PlayerId" });
            DropIndex("dbo.Game", new[] { "PlatFormId" });
            DropIndex("dbo.Comment", new[] { "PlayerId" });
            DropIndex("dbo.Comment", new[] { "GameId" });
            DropTable("dbo.PlatForm");
            DropTable("dbo.Player");
            DropTable("dbo.MyGames");
            DropTable("dbo.Game");
            DropTable("dbo.Comment");
        }
    }
}
