namespace SocialGames.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Implemention_Comments : DbMigration
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
                .ForeignKey("dbo.Player", t => t.PlayerId)
                .ForeignKey("dbo.Game", t => t.GameId)
                .Index(t => t.GameId)
                .Index(t => t.PlayerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comment", "GameId", "dbo.Game");
            DropForeignKey("dbo.Comment", "PlayerId", "dbo.Player");
            DropIndex("dbo.Comment", new[] { "PlayerId" });
            DropIndex("dbo.Comment", new[] { "GameId" });
            DropTable("dbo.Comment");
        }
    }
}
